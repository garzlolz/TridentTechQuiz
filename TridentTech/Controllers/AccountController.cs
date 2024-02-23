using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;
using TridentTech.Const;
using TridentTech.Models;
using TridentTech.Services.Interface;

namespace TridentTech.Controllers
{
    [ApiController]
    [Tags("帳號相關-Account")]
    public class AccountController : ControllerBase
    {
        private readonly ILoginService _loginService;

        public AccountController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        /// <summary>
        /// 學生或講師登入
        /// </summary>
        /// <param name="param">輸入參數</param>
        /// <returns></returns>
        /// <remarks>
        /// 備註 : 回傳的會員Token用於需傳入Authorize的Api。
        /// </remarks>
        [HttpPost]
        [SwaggerResponse(StatusCodes.Status200OK, $"{ResponseMessage.SuccessCode}:{ResponseMessage.Success}", typeof(ResultResponse<LoginResponseModel>))]
        [SwaggerResponse(StatusCodes.Status401Unauthorized, $"{ResponseMessage.AccountNotFoundCode}:{ResponseMessage.AccountNotFound}<br>{ResponseMessage.PasswordErrorCode}:{ResponseMessage.PasswordError}")]
        [Route("api/Login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestModel param, [Required] bool isTeacher = false)
        {
            var result = await _loginService.Login(isTeacher, param);
            return StatusCode(StatusCodes.Status200OK, result);
        }

        /// <summary>
        /// 註冊學生或講師帳號
        /// </summary>
        /// <param name="isTeacher"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        [HttpPost]
        [SwaggerResponse(StatusCodes.Status200OK, $"{ResponseMessage.SuccessCode}:{ResponseMessage.Success}", typeof(ResultResponse))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, $"{ResponseMessage.AccountIsRegisted}:{ResponseMessage.AccountIsRegistedCode}")]
        [Route("api/Register")]
        public async Task<IActionResult> Register([FromBody][Required] RegisterRequestModel param, [Required] bool isTeacher = false)
        {
            var result = await _loginService.Register(isTeacher, param);
            return StatusCode(StatusCodes.Status200OK, result);
        }
    }
}
