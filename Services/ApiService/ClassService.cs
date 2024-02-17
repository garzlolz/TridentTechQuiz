using Microsoft.EntityFrameworkCore;
using System.Net;
using TridentTech.Const;
using TridentTech.DBModels;
using TridentTech.Models;
using TridentTech.Services.Interface;

namespace TridentTech.Services.ApiService
{
    public class ClassService : IClassService
    {
        public TridentTechContext DB { get; }
        public ClassService(TridentTechContext db)
        {
            DB = db;
        }

        /// <summary>
        /// 新增課程
        /// </summary>
        /// <param name="request"></param>
        /// <returns>Id</returns>
        public async Task<ResultResponse<int>> AddClass(ClassBaseModel request)
        {
            ResultResponse<int> result = new();

            if (request.TeacherId.HasValue
                && await DB.Teachers.AnyAsync(t => t.Id == request.TeacherId))
            {
                result.HttpStatus = StatusCodes.Status404NotFound;
                result.Code = ResponseMessage.TeacherNotFoundCode;
                result.Message = ResponseMessage.TeacherNotFound;
                return result;
            }

            if (!CheckIsValidTime(request.StartAt) || !CheckIsValidTime(request.EndAt))
            {
                result.HttpStatus = StatusCodes.Status400BadRequest;
                result.Code = ResponseMessage.TimeIsNotValidCode;
                result.Message = ResponseMessage.TimeIsNotValid;
                return result;
            }

            if (!CompareIsValidStartEndTime(request.StartAt, request.EndAt))
            {
                result.HttpStatus = StatusCodes.Status400BadRequest;
                result.Code = ResponseMessage.TimeIsNotValidCode;
                result.Message = ResponseMessage.TimeIsNotValid;
                return result;
            }

            var data = new Class
            {
                ClassName = request.ClassName,
                Description = request.Description,
                StartAt = request.StartAt,
                EndAt = request.EndAt,
                TeacherId = request.TeacherId
            };

            await DB.Classes.AddAsync(data);
            await DB.SaveChangesAsync();

            result.Data = data.Id;
            return result;
        }

        /// <summary>
        /// 刪除課程
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ResultResponse> DeleteClass(int id)
        {
            ResultResponse result = new();

            var deleteCount = await DB.Classes.Where(w => w.Id == id).ExecuteDeleteAsync();

            if (deleteCount == 0)
            {
                result.HttpStatus = StatusCodes.Status404NotFound;
                result.Code = ResponseMessage.ClassNotFoundCode;
                result.Message = ResponseMessage.ClassNotFound;
                return result;
            }

            return result;
        }

        /// <summary>
        /// 取得課程
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ResultResponse<ClassModel>> GetClass(int id)
        {
            ResultResponse<ClassModel> result = new()
            {
                Data = await DB.Classes.Select(c => new ClassModel
                {
                    Id = c.Id,
                    ClassName = c.ClassName,
                    Description = c.Description,
                    StartAt = c.StartAt,
                    EndAt = c.EndAt,
                })
                .FirstOrDefaultAsync(c => c.Id == id)
            };

            if (result.Data == null)
            {
                result.HttpStatus = StatusCodes.Status404NotFound;
                result.Code = ResponseMessage.ClassNotFoundCode;
                result.Message = ResponseMessage.ClassNotFound;
                return result;
            }

            return result;
        }

        /// <summary>
        /// 取得課程列表
        /// </summary>
        /// <returns></returns>
        public async Task<ResultResponse<List<ClassListModel>>> GetClasses()
        {
            ResultResponse<List<ClassListModel>?> result = new();

            result.Data = await DB.Classes
                .Select(c => new ClassListModel
                {
                    Id = c.Id,
                    ClassName = c.ClassName,
                    StartAt = c.StartAt,
                    EndAt = c.EndAt,
                    TeacherId = c.TeacherId,
                    TeacherName = c.Teacher.Name
                })
                .OrderByDescending(c => c.Id)
                .Take(2)
                .ToListAsync();

            return result;
        }

        /// <summary>
        /// 更新課程
        /// </summary>
        /// <param name="id"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<ResultResponse> UpdateClass(int id, ClassBaseModel request)
        {
            ResultResponse result = new();

            var @class = await DB.Classes.FindAsync(id);

            if (@class == null)
            {
                result.HttpStatus = StatusCodes.Status404NotFound;
                result.Code = ResponseMessage.ClassNotFoundCode;
                result.Message = ResponseMessage.ClassNotFound;
                return result;
            }

            @class.ClassName = request.ClassName!;
            @class.Description = request.Description!;

            if (!CheckIsValidTime(request.StartAt) || !CheckIsValidTime(request.EndAt))
            {
                result.HttpStatus = StatusCodes.Status400BadRequest;
                result.Code = ResponseMessage.TimeIsNotValidCode;
                result.Message = ResponseMessage.TimeIsNotValid;
                return result;
            }

            @class.StartAt = request.StartAt;
            @class.EndAt = request.EndAt;

            if (request.TeacherId.HasValue)
            {
                if (!await DB.Teachers.AnyAsync(t => t.Id == request.TeacherId))
                {
                    result.HttpStatus = StatusCodes.Status404NotFound;
                    result.Code = ResponseMessage.TeacherNotFoundCode;
                    result.Message = ResponseMessage.TeacherNotFound;
                    return result;
                }

                @class.TeacherId = request.TeacherId;
            }

            await DB.SaveChangesAsync();

            return result;
        }

        /// <summary>
        /// 檢查是否為合法時間格式
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public bool CheckIsValidTime(string time)
        {
            bool isValid = false;

            try
            {
                if (time.Length != 4)
                {
                    return isValid;
                }

                var hours = Convert.ToInt32(time.Substring(0, 2));
                var minutes = Convert.ToInt32(time.Substring(2, 2));

                if (hours >= 24 || minutes >= 60)
                {
                    return isValid;
                }

                isValid = true;
                return isValid;
            }
            catch (Exception ex)
            {
                return isValid;
            }

        }

        /// <summary>
        /// 檢查是否為合法時間格式
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public bool CompareIsValidStartEndTime(string startAt, string endAt)
        {
            bool isValid = false;

            try
            {
                var starTime = Convert.ToInt32(startAt);
                var endTime = Convert.ToInt32(endAt);

                if (starTime >= endTime)
                {
                    return isValid;
                }

                isValid = true;
                return isValid;
            }
            catch (Exception ex)
            {
                return isValid;
            }

        }
    }
}
