using TridentTech.Models;

namespace TridentTech.Services.Interface
{
    public interface ILoginService
    {
        /// <summary>
        /// 登入學生或講師
        /// </summary>
        /// <param name="param">輸入參數</param>
        /// <returns></returns>
        public Task<ResultResponse<LoginResponseModel>> Login(bool isTeacher, LoginRequestModel param);
        /// <summary>
        /// 檢查該帳號是否可用 (for Authorize attribute)
        /// </summary>
        /// <param name="userId">會員Id</param>
        /// <returns></returns>
        public ResultResponse<bool> CheckAccountAvailable(string userId);
        /// <summary>
        /// 註冊學生或講師
        /// </summary>
        /// <param name="param">輸入參數</param>
        /// <returns></returns>
        public Task<ResultResponse> Register(bool isTeacher, RegisterRequestModel param);
    }
}
