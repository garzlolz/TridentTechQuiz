using Azure;
using Microsoft.EntityFrameworkCore;
using System.Net;
using TridentTech.Const;
using TridentTech.DBModels;
using TridentTech.Models;
using TridentTech.Services.Interface;

namespace TridentTech.Services.ApiService
{
    public class LoginService : ILoginService
    {
        private readonly TridentTechContext DB;
        private readonly IJwtService _jwtService;

        public LoginService(TridentTechContext db, IJwtService jwtService)
        {
            DB = db;
            _jwtService = jwtService;
        }

        public async Task<ResultResponse<LoginResponseModel>> Login(LoginRequestModel param)
        {
            ResultResponse<LoginResponseModel> result = new();

            var member = await DB.Members
            .Where(m => m.Account == param.Account
                && m.IsTeacher == param.IsTeacher)
            .FirstOrDefaultAsync();

            // 尚未註冊
            if (member == null)
            {
                result.HttpStatus = StatusCodes.Status401Unauthorized;
                result.Code = ResponseMessage.AccountNotFoundCode;
                result.Message = ResponseMessage.AccountNotFound;
                return result;
            }

            // 密碼錯誤
            if (member.Password != param.Password)
            {
                result.HttpStatus = StatusCodes.Status401Unauthorized;
                result.Code = ResponseMessage.PasswordErrorCode;
                result.Message = ResponseMessage.PasswordError;
                return result;
            }

            result.Data = new()
            {
                Token = _jwtService.GetApiJwt(member.Id, member.IsTeacher)
            };

            return result;
        }

        /// <summary>
        /// 檢查該帳號是否可用 (for Authorize attribute)
        /// </summary>
        /// <param name="userId">會員Id</param>
        /// <returns></returns>
        public ResultResponse<bool> CheckAccountAvailable(string userId)
        {
            ResultResponse<bool> result = new();
            var now = DateTime.Now;

            var member = DB.Members
                .Where(m => m.Id == Convert.ToInt32(userId)
                    && !string.IsNullOrEmpty(m.Password))
                .AsNoTracking()
                .FirstOrDefault();

            // 找不到該會員
            if (member == null)
            {
                result.HttpStatus = StatusCodes.Status401Unauthorized;
                result.Code = ResponseMessage.MemberNotFoundCode;
                result.Code = ResponseMessage.MemberNotFound;
                result.Data = false;

                return result;
            }

            return result;
        }

        /// <summary>
        /// 註冊
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public async Task<ResultResponse> Register(RegisterRequestModel param)
        {
            ResultResponse result = new();

            var isExist = await DB.Members.AnyAsync(m => m.Account == param.Account && m.IsTeacher == param.IsTeacher);

            if (isExist)
            {
                result.HttpStatus = StatusCodes.Status400BadRequest;
                result.Code = ResponseMessage.AccountIsRegisted;
                result.Message = ResponseMessage.AccountIsRegistedCode;
                return result;
            }

            var member = new Member
            {
                Account = param.Account,
                Password = param.Password,
                Email = param.Email,
                Name = param.Name,
                IsTeacher = param.IsTeacher
            };

            await DB.Members.AddRangeAsync(member);
            await DB.SaveChangesAsync();

            return result;
        }
    }
}
