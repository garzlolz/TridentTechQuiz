using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using TridentTech.Const;
using TridentTech.Models;
using TridentTech.Services.Interface;

namespace TridentTech.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService _loginService;

        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        /// <summary>
        /// 1001 登入
        /// </summary>
        /// <param name="param">輸入參數</param>
        /// <returns></returns>
        /// <remarks>
        /// 備註 : 回傳的會員Token用於需傳入Authorize的Api。
        /// </remarks>
        [HttpPost]
        [SwaggerResponse(StatusCodes.Status200OK, $"{ResponseMessage.SuccessCode}:{ResponseMessage.Success}", typeof(ResultResponse<LoginResponseModel>))]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestModel param)
        {
            var result = await _loginService.Login(param);
            return StatusCode(StatusCodes.Status200OK, result);
        }


        /// <summary>
        /// 註冊學生或講師帳號
        /// </summary>
        /// <param name="param">輸入參數</param>
        [HttpPost]
        [SwaggerResponse(StatusCodes.Status200OK, $"{ResponseMessage.SuccessCode}:{ResponseMessage.Success}", typeof(ResultResponse))]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequestModel param)
        {
            var result = await _loginService.Register(param);
            return StatusCode(StatusCodes.Status200OK, result);
        }
    }
}
