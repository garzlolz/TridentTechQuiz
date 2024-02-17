using TridentTech.Models;

namespace TridentTech.Services.Interface
{
    public interface ILoginService
    {
        /// <summary>
        /// 登入
        /// </summary>
        /// <param name="param">輸入參數</param>
        /// <returns></returns>
        public Task<ResultResponse<LoginResponseModel>> Login(LoginRequestModel param);
        /// <summary>
        /// 檢查該帳號是否可用 (for Authorize attribute)
        /// </summary>
        /// <param name="userId">會員Id</param>
        /// <returns></returns>
        public ResultResponse<bool> CheckAccountAvailable(string userId);
        /// <summary>
        /// 註冊
        /// </summary>
        /// <param name="param">輸入參數</param>
        /// <returns></returns>
        public Task<ResultResponse> Register(RegisterRequestModel param);
    }
}
