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

            var data = new Teacher
            {
                Name = request.Name,
                Email = request.Email
            };

            await DB.Teachers.AddAsync(data);
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

            result.Data = await DB.Teachers.Include(t => t.Classes)
                .Select(t => new TeacherClassModel
                {
                    Id = t.Id,
                    Name = t.Name,
                    Email = t.Email,
                    Classes = t.Classes.Select(c => new ClassModel
                    {
                        Id = c.Id,
                        ClassName = c.ClassName,
                        Description = c.Description,
                        StartAt = c.StartAt,
                        EndAt = c.EndAt
                    })
                    .OrderByDescending(c => c.Id)
                    .Take(2)
                    .ToList()
                })
                .FirstOrDefaultAsync(t => t.Id == id);

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
        public async Task<ResultResponse<List<TeacherModel>?>> GetTeachers()
        {
            ResultResponse<List<TeacherModel>?> result = new()
            {
                Data = await DB.Teachers.Select(t => new TeacherModel
                {
                    Id = t.Id,
                    Name = t.Name,
                    Email = t.Email
                })
                .OrderByDescending(t => t.Id)
                .Take(2)
                .ToListAsync()
            };

            return result;
        }
    }
}
