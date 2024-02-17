using Azure.Core;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using TridentTech.Const;
using TridentTech.Models;
using TridentTech.Services.Interface;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TridentTech.Controllers
{
    /// <summary>
    /// 課程相關
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Tags("課程相關-Class")]
    public class ClassController : ControllerBase
    {
        private readonly IClassService _classService;

        public ClassController(IClassService classService)
        {
            _classService = classService;
        }

        /// <summary>
        /// 取得課程列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [SwaggerResponse(StatusCodes.Status200OK, $"{ResponseMessage.SuccessCode}:{ResponseMessage.Success}", typeof(List<ClassListModel>))]
        public async Task<IActionResult> Get()
        {
            var result = await _classService.GetClasses();
            return StatusCode(StatusCodes.Status200OK, result);
        }

        /// <summary>
        /// 取得課程詳細資訊
        /// </summary>
        /// <param name="id">課程Id</param>
        /// <returns></returns>
        [SwaggerResponse(StatusCodes.Status200OK, $"{ResponseMessage.SuccessCode}:{ResponseMessage.Success}", typeof(ResultResponse<ClassBaseModel>))]
        [SwaggerResponse(StatusCodes.Status404NotFound, $"{ResponseMessage.ClassNotFoundCode}:{ResponseMessage.ClassNotFound}")]
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _classService.GetClass(id);
            return StatusCode(result.HttpStatus, result);
        }

        /// <summary>
        /// 建立新課程
        /// </summary>
        /// <param name="request"></param>
        /// <returns>Data = Id</returns>
        [HttpPost]
        [SwaggerResponse(StatusCodes.Status200OK, $"{ResponseMessage.SuccessCode}:{ResponseMessage.Success}", typeof(ResultResponse<int>))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, $"{ResponseMessage.TimeIsNotValidCode}:{ResponseMessage.TimeIsNotValid}")]
        [SwaggerResponse(StatusCodes.Status404NotFound, $"{ResponseMessage.TeacherNotFoundCode}:{ResponseMessage.TeacherNotFound}")]
        public async Task<IActionResult> Post([FromBody] ClassBaseModel request)
        {
            var result = await _classService.AddClass(request);
            return StatusCode(result.HttpStatus, result);
        }

        /// <summary>
        /// 更新課程
        /// </summary>
        /// <param name="id">課程Id</param>
        /// <param name="request">課程資訊</param>
        [HttpPut("{id}")]
        [SwaggerResponse(StatusCodes.Status200OK, $"{ResponseMessage.SuccessCode}:{ResponseMessage.Success}", typeof(ResultResponse<ClassListModel>))]
        [SwaggerResponse(StatusCodes.Status404NotFound,
            $"{ResponseMessage.ClassNotFoundCode}:{ResponseMessage.ClassNotFound}<br>" +
            $"{ResponseMessage.TeacherNotFoundCode}:{ResponseMessage.TeacherNotFound}")]
        public async Task<IActionResult> Put(int id, [FromBody] ClassBaseModel request)
        {
            var result = await _classService.UpdateClass(id, request);
            return StatusCode(result.HttpStatus, result);
        }

        /// <summary>
        /// 刪除課程
        /// </summary>
        /// <param name="id">課程Id</param>
        [SwaggerResponse(StatusCodes.Status200OK, $"{ResponseMessage.SuccessCode}:{ResponseMessage.Success}")]
        [SwaggerResponse(StatusCodes.Status404NotFound, $"{ResponseMessage.ClassNotFoundCode}:{ResponseMessage.ClassNotFound}")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _classService.DeleteClass(id);
            return StatusCode(result.HttpStatus, result);
        }
    }
}
