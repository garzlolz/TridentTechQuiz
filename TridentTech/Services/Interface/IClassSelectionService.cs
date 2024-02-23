
using TridentTech.Models;

namespace TridentTech.Services.Interface
{
    public interface IClassSelectionService
    {
        /// <summary>
        /// 學生刪除選課
        /// </summary>
        /// <param name="classId"></param>
        /// <returns></returns>
        public Task<ResultResponse> DeleteSelection(int classId);
        /// <summary>
        /// 取得學生選課列表
        /// </summary>
        /// <returns></returns>
        public Task<ResultResponse<List<GetSelectionsResponseModel>>> GetSelections();
        /// <summary>
        /// 查詢指定課程選課學生清單
        /// </summary>
        /// <param name="classId"></param>
        /// <returns></returns>
        public Task<ResultResponse<List<GetStudentsResponseModel>>> GetStudents(int classId);
        /// <summary>
        /// 選課或修改選課結果
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<ResultResponse> CreateOrUpdateSelection(CreateOrUpdateSelectionModel request);
    }
}
