using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using TridentTech.Const;
using TridentTech.Models;
using TridentTech.Services.Interface;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TridentTech.Controllers
{
    /// <summary>
    /// 講師相關
    /// </summary>
    [Tags("講師相關-Teachers")]
    [Route("api/[controller]")]
    [ApiController]
    public class TeachersController : ControllerBase
    {
        private readonly ITeacherService _teacherService;

        public TeachersController(ITeacherService teacherService)
        {
            _teacherService = teacherService;
        }

        /// <summary>
        /// 取得講師資訊列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [SwaggerResponse(StatusCodes.Status200OK, $"{ResponseMessage.SuccessCode}:{ResponseMessage.Success}", typeof(ResultResponse<GetTeachersModel>))]
        public async Task<IActionResult> Get()
        {
            var result = await _teacherService.GetTeachers();
            return StatusCode(result.HttpStatus, result);
        }

        /// <summary>
        /// 取得講師開課列表
        /// </summary>
        /// <param name="memberId">講師的會員Id</param>
        /// <returns></returns>
        [SwaggerResponse(StatusCodes.Status200OK, $"{ResponseMessage.SuccessCode}:{ResponseMessage.Success}", typeof(ResultResponse<TeacherClassModel>))]
        [SwaggerResponse(StatusCodes.Status404NotFound, $"{ResponseMessage.TeacherNotFoundCode}:{ResponseMessage.TeacherNotFound}")]
        [HttpGet("{memberId}")]
        public async Task<IActionResult> Get(int memberId)
        {
            var result = await _teacherService.GetTeacher(memberId);
            return StatusCode(result.HttpStatus, result);
        }

        /// <summary>
        /// 建立講師 (需登入講師帳號)
        /// </summary>
        /// <param name="request"></param>
        [HttpPost]
        [SwaggerResponse(StatusCodes.Status200OK, $"{ResponseMessage.SuccessCode}:{ResponseMessage.Success}", typeof(ResultResponse<TeacherClassModel>))]
        [SwaggerResponse(StatusCodes.Status400BadRequest,$"{ResponseMessage.AccountIsRegistedCode}:{ResponseMessage.AccountIsRegisted}")]
        [SwaggerResponse(StatusCodes.Status401Unauthorized,$"{ResponseMessage.UnauthorizedCode}:{ResponseMessage.Unauthorized}")]
        [IdentityAuthorize(true)]
        public async Task<IActionResult> Post([FromBody] TeacherBaseModel request)
        {
            var result = await _teacherService.AddTeacher(request);
            return StatusCode(result.HttpStatus, result);
        }
    }
}
