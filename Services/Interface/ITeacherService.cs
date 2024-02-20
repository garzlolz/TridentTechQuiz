
using TridentTech.Models;

namespace TridentTech.Services.Interface
{
    /// <summary>
    /// 講師相關介面
    /// </summary>
    public interface ITeacherService
    {
        /// <summary>
        /// 新增講師
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public Task<ResultResponse> AddTeacher(TeacherBaseModel request);
        /// <summary>
        /// 取得講師
        /// </summary>
        /// <param name="memberId"></param>
        /// <returns></returns>
        public Task<ResultResponse<TeacherClassModel>> GetTeacher(int memberId);
        /// <summary>
        /// 取得講師列表
        /// </summary>
        /// <returns></returns>
        public Task<ResultResponse<List<GetTeachersModel>?>> GetTeachers();
    }
}
