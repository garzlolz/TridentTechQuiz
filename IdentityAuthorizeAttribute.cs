using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TridentTech.Models;
using TridentTech.Services.Interface;
using TridentTech.Const;

namespace TridentTech
{
    /// <summary>
    /// 前台身分驗證 Authorize attribute
    /// </summary>
    [AttributeUsage(AttributeTargets.All)]
    public class IdentityAuthorizeAttribute : Attribute, IAuthorizationFilter
    {
        private ILoginService _authService;
        private IdentityAuthorizeFilter _identityAuthorizeFilter;

        public IdentityAuthorizeAttribute(bool checkIsTeacher = false)
        {
            CheckIsTeacher = checkIsTeacher;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            _authService = context.HttpContext.RequestServices.GetService(typeof(ILoginService)) as ILoginService;

            _identityAuthorizeFilter = new IdentityAuthorizeFilter(CheckIsTeacher, _authService);

            _identityAuthorizeFilter.OnAuthorization(context);
        }

        /// <summary>
        /// 是否需判斷為老師
        /// </summary>
        public bool CheckIsTeacher { get; set; } = false;
    }

    public class IdentityAuthorizeFilter : IAuthorizationFilter
    {
        private bool _checkIsTeacher;
        private readonly ILoginService _authService;
        public IdentityAuthorizeFilter(bool checkIsTeacher, ILoginService authService)
        {
            _checkIsTeacher = checkIsTeacher;
            _authService = authService;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            ResultResponse result = new();

            var user = context.HttpContext.User;
            var authHeader = context.HttpContext.Request.Headers["Authorization"].FirstOrDefault();

            var isTeacher = Convert.ToBoolean(user.Claims.Where(c => c.Type == ClaimTypes.Role)
                .Select(c => c.Value)
                .FirstOrDefault());

            if (user.Identity == null
                || !user.Identity.IsAuthenticated || string.IsNullOrEmpty(authHeader))
            {

                result = new()
                {
                    Code = ResponseMessage.UnauthorizedCode,
                    Message = ResponseMessage.Unauthorized
                };

                context.Result = new JsonResult(result)
                {
                    StatusCode = StatusCodes.Status401Unauthorized
                };

                return;
            }

            // 檢查Token UserId
            var userId = user.FindFirstValue(ClaimTypes.NameIdentifier);

            // 身分是否符合老師或學生
            if (string.IsNullOrEmpty(userId) || _checkIsTeacher != isTeacher)
            {
                result = new()
                {
                    Code = ResponseMessage.UnauthorizedCode,
                    Message = ResponseMessage.Unauthorized
                };

                context.Result = new JsonResult(result)
                {
                    StatusCode = StatusCodes.Status401Unauthorized
                };

                return;
            }

            // 檢查該帳號是否可用
            var checkResult = _authService.CheckAccountAvailable(userId);

            if (checkResult.HttpStatus != StatusCodes.Status200OK)
            {
                result = new()
                {
                    Code = checkResult.Code!,
                    Message = checkResult.Message!
                };

                context.Result = new JsonResult(result)
                {
                    StatusCode = checkResult.HttpStatus
                };

                return;
            }
        }
    }
}
