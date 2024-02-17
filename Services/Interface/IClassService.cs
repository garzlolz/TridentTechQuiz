
using TridentTech.Models;

namespace TridentTech.Services.Interface
{
    /// <summary>
    /// 課程服務介面
    /// </summary>
    public interface IClassService
    {
        /// <summary>
        /// 取得課程列表
        /// </summary>
        /// <returns></returns>
        public Task<ResultResponse<List<ClassListModel>>> GetClasses();
        /// <summary>
        /// 取得課程詳細資訊
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<ResultResponse<ClassModel>> GetClass(int id);
        /// <summary>
        /// 新增課程
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public Task<ResultResponse<int>> AddClass(ClassBaseModel request);
        /// <summary>
        /// 更新課程
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public Task<ResultResponse> UpdateClass(int id, ClassBaseModel request);
        /// <summary>
        /// 刪除課程
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<ResultResponse> DeleteClass(int id);
    }
}
