namespace TridentTech.Models
{
    /// <summary>
    /// 取得當前學生選課列表 Response Model
    /// </summary>
    public class GetSelectionsResponseModel
    {
        /// <summary>
        /// 課程Id
        /// </summary>
        public int ClassId { get; set; }
        /// <summary>
        /// 講師會員Id
        /// </summary>
        public int TeacherMemberId { get; set; }
        /// <summary>
        /// 講師名稱
        /// </summary>
        public string? TeacherName { get; set; }
    }

    /// <summary>
    /// 查詢指定課程選課學生清單 ResponseModel
    /// </summary>
    public class GetStudentsResponseModel
    {
        /// <summary>
        /// 學生會員Id
        /// </summary>
        public int StudentMemeberId { get; set; }
        /// <summary>
        /// 學生名稱
        /// </summary>
        public string? StudentName { get; set; }
    }

    /// <summary>
    /// 選課或修改選課結果 Request Model
    /// </summary>
    public class CreateOrUpdateSelectionModel
    {
        /// <summary>
        /// 課程Id
        /// </summary>
        public int ClassId { get; set; }
    }
}
