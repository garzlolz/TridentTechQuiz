using Microsoft.EntityFrameworkCore;
using TridentTech.Const;
using TridentTech.DBModels;
using TridentTech.Models;
using TridentTech.Services.Interface;

namespace TridentTech.Services.ApiService
{
    public class TeacherService : ITeacherService
    {
        public TridentTechContext DB { get; }
        public TeacherService(TridentTechContext db)
        {
            DB = db;
        }

        /// <summary>
        /// 新增講師
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<ResultResponse> AddTeacher(TeacherBaseModel request)
        {
            ResultResponse result = new();

            var isExist = await DB.Members.AnyAsync(m => request.Account == m.Account && m.IsTeacher);

            if (isExist)
            {
                result.HttpStatus = StatusCodes.Status400BadRequest;
                result.Code = ResponseMessage.AccountIsRegistedCode;
                result.Message = ResponseMessage.AccountIsRegisted;
                return result;
            }

            Member member = new()
            {
                Account = request.Account,
                Password = request.Password,
                Name = request.Name,
                Email = request.Email,
                IsTeacher = true
            };

            await DB.Members.AddAsync(member);
            await DB.SaveChangesAsync();

            return result;
        }

        /// <summary>
        /// 取得講師
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ResultResponse<TeacherClassModel>> GetTeacher(int id)
        {
            ResultResponse<TeacherClassModel> result = new();

            result.Data = await DB.Members
                .Where(m => m.Id == id && m.IsTeacher)
                .Select(m => new TeacherClassModel
                {
                    Id = m.Id,
                    Name = m.Name,
                    Email = m.Email,
                    Classes = m.Classes.Select(c => new ClassModel
                    {
                        Id = c.Id,
                        ClassName = c.ClassName,
                        Description = c.Description,
                        StartAt = c.StartAt,
                        EndAt = c.EndAt
                    })
                    .ToList()
                })
                .FirstOrDefaultAsync();

            if (result.Data == null)
            {
                result.HttpStatus = StatusCodes.Status404NotFound;
                result.Code = ResponseMessage.TeacherNotFoundCode;
                result.Message = ResponseMessage.TeacherNotFound;
                return result;
            }

            return result;
        }

        /// <summary>
        /// 取得講師列表
        /// </summary>
        /// <returns></returns>
        public async Task<ResultResponse<List<GetTeachersModel>?>> GetTeachers()
        {
            ResultResponse<List<GetTeachersModel>?> result = new()
            {
                Data = await DB.Members
                .Where(m => m.IsTeacher)
                .Select(m => new GetTeachersModel
                {
                    TeacherMemberId = m.Id,
                    Email = m.Email,
                    Name = m.Name,
                })
                .Take(2)
                .ToListAsync()
            };

            return result;
        }
    }
}
