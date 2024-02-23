using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using TridentTech.Const;
using TridentTech.DBModels;
using TridentTech.Models;
using TridentTech.Services.Interface;

namespace TridentTech.Services.ApiService
{
    public class ClassSelectionService : IClassSelectionService
    {
        private readonly HttpContext _context;
        private readonly int? _memberId;
        private readonly TridentTechContext DB;


        public ClassSelectionService(HttpContext context, TridentTechContext db)
        {
            _context = context;
            _memberId = Convert.ToInt32(_context.User.FindFirstValue(ClaimTypes.NameIdentifier));
            DB = db;
        }

        public async Task<ResultResponse> DeleteSelection(int classId)
        {
            ResultResponse result = new();

            var classSelectione = await DB.ClassSelectiones.FirstOrDefaultAsync(c => c.ClassId == classId && c.MemberId == _memberId);

            if (classSelectione == null)
            {
                result.HttpStatus = StatusCodes.Status404NotFound;
                result.Code = ResponseMessage.ClassNotFoundCode;
                result.Message = ResponseMessage.ClassNotFound;
                return result;
            }

            DB.ClassSelectiones.Remove(classSelectione);
            await DB.SaveChangesAsync();

            return result;
        }

        /// <summary>
        /// 取得當前學生選課列表
        /// </summary>
        /// <returns></returns>
        public async Task<ResultResponse<List<GetSelectionsResponseModel>>> GetSelections()
        {
            ResultResponse<List<GetSelectionsResponseModel>> result = new()
            {
                Data = await DB.ClassSelectiones.Where(c => c.MemberId == _memberId)
                .Select(cs => new GetSelectionsResponseModel
                {
                    ClassId = cs.ClassId,
                    TeacherMemberId = cs.Class.MemberId!.Value,
                    TeacherName = cs.Class.Member!.Name
                })
                .ToListAsync()
            };

            return result;
        }

        /// <summary>
        /// 查詢指定課程選課學生清單
        /// </summary>
        /// <param name="classId"></param>
        /// <returns></returns>
        public async Task<ResultResponse<List<GetStudentsResponseModel>>> GetStudents(int classId)
        {
            ResultResponse<List<GetStudentsResponseModel>> result = new()
            {
                Data = await DB.ClassSelectiones.Where(c => c.ClassId == classId)
                .Select(c => new GetStudentsResponseModel
                {
                    StudentMemeberId = c.MemberId,
                    StudentName = c.Member.Name
                })
                .ToListAsync()
            };

            return result;
        }

        /// <summary>
        /// 選課或修改選課結果
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<ResultResponse> CreateOrUpdateSelection(CreateOrUpdateSelectionModel request)
        {
            ResultResponse result = new();
            ClassSelection classSelection;

            var @class = await DB.Classes.FirstOrDefaultAsync(r => r.Id == request.ClassId);

            if (@class == null)
            {
                result.HttpStatus = StatusCodes.Status404NotFound;
                result.Code = ResponseMessage.ClassNotFoundCode;
                result.Message = ResponseMessage.ClassNotFound;
                return result;
            }

            var selection = await DB.ClassSelectiones.FirstOrDefaultAsync(c => c.ClassId == request.ClassId && c.MemberId == _memberId);

            if (selection == null)
            {
                classSelection = new();
            }
            else
            {
                classSelection = selection;
            }

            classSelection.ClassId = request.ClassId;
            classSelection.MemberId = _memberId!.Value;

            if (classSelection.Id == 0)
            {
                await DB.ClassSelectiones.AddAsync(classSelection);
            }

            await DB.SaveChangesAsync();
            return result;
        }
    }
}
