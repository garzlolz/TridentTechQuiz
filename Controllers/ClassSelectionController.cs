using Microsoft.AspNetCore.Mvc;
using TridentTech.Models;
using TridentTech.Services.Interface;

namespace TridentTech.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassSelectionController : ControllerBase
    {
        private readonly IClassSelectionService _selectionService;

        public ClassSelectionController(IClassSelectionService selectionService)
        {
            _selectionService = selectionService;
        }

        /// <summary>
        /// 取得當前學生選課列表(需登入學生帳號)
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [IdentityAuthorize]
        public async Task<IActionResult> GetSelections()
        {
            var result = await _selectionService.GetSelections();
            return StatusCode(result.HttpStatus, result);
        }

        /// <summary>
        /// 查詢指定課程選課學生清單 (需登入講師帳號)
        /// </summary>
        /// <param name="classId"></param>
        /// <returns></returns>
        [HttpGet("{classId}")]
        [IdentityAuthorize(true)]
        public async Task<IActionResult> GetStudents(int classId)
        {
            var result = await _selectionService.GetStudents(classId);
            return StatusCode(result.HttpStatus, result);
        }

        /// <summary>
        /// 選課或修改選課結果 (需登入學生帳號)
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [IdentityAuthorize]
        public async Task<IActionResult> Post([FromBody] CreateOrUpdateSelectionModel request)
        {
            var result = await _selectionService.CreateOrUpdateSelection(request);
            return StatusCode(result.HttpStatus, result);
        }

        /// <summary>
        /// 刪除選課 (需登入學生帳號)
        /// </summary>
        /// <param name="classId"></param>
        [HttpDelete("{id}")]
        [IdentityAuthorize]
        public async Task<IActionResult> Delete(int classId)
        {
            var result = await _selectionService.DeleteSelection(classId);
            return StatusCode(result.HttpStatus, result);
        }
    }
}
