namespace TridentTech.Const
{
    /// <summary>
    /// 回傳代碼、訊息
    /// </summary>
    public static class ResponseMessage
    {
        /// <summary>
        /// "1"
        /// </summary>
        public const string SuccessCode = "1";
        /// <summary>
        /// success
        /// </summary>
        public const string Success = "成功";

        #region Fail
        /// <summary>
        /// Fail : 0
        /// </summary>
        public const string FailCode = "0";
        /// <summary>
        /// Fail : 0
        /// </summary>  
        public const string Fail = "失敗";
        #endregion

        #region 400 Bad Request
        public const string TimeIsNotValidCode = "40000";
        public const string TimeIsNotValid = "請輸入合法時間";
        public const string AccountIsRegistedCode = "40001";
        public const string AccountIsRegisted = "此會員帳號已被註冊";

        #endregion

        #region 401 Unauthorize
        public const string UnauthorizedCode = "41000";
        public const string Unauthorized = "未經授權";
        public const string MemberNotFoundCode = "41001";
        public const string MemberNotFound = "找不到該會員";
        public const string AccountNotFoundCode = "41002";
        public const string AccountNotFound = "查無此會員帳號";
        public const string PasswordErrorCode = "41003";
        public const string PasswordError = "密碼錯誤";
        public const string AccountPasswordIncorrect = "帳號或密碼錯誤";
        #endregion

        #region 403 Forbidden
        #endregion

        #region 404 Data Not Found
        public const string DataNotFoundCode = "44000";
        public const string DataNotFound = "找不到資料";
        public const string TeacherNotFoundCode = "44001";
        public const string TeacherNotFound = "找不到該講師";
        public const string ClassNotFoundCode = "44002";
        public const string ClassNotFound = "找不到該課程";
        #endregion

        #region 500 Server Error
        public const string ServerErrorCode = "50000";
        public const string ServerError = "伺服器發生錯誤";
        #endregion
    }
}
