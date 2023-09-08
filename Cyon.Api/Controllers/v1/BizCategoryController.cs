using Cyon.Domain.Common;
using Cyon.Domain.DTOs.Biz;
using Cyon.Domain.Models.Biz;
using Cyon.Domain.Services;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Cyon.Api.Controllers.v1
{
    public class BizCategoryController : BaseController
    {
        private readonly IBizCategoryCategoryService _bizCategoryCategoryService;

        public BizCategoryController(IBizCategoryCategoryService bizCategoryCategoryService)
        {
            _bizCategoryCategoryService = bizCategoryCategoryService;
        }

        [HttpGet("GetBizCategorys")]
        public async Task<ActionResult<IEnumerable<BizCategoryModel>>> GetBizs([FromQuery] Pagination pagination)
        {
            var response = await _bizCategoryCategoryService.GetBizCategorys(pagination);
            return Ok(response);
        }

        [HttpGet("GetBizCategory/{bizId}", Name = "GetBizCategory")]
        public async Task<ActionResult<BizCategoryModel>> GetBizCategory(Guid bizId)
        {
            var response = await _bizCategoryCategoryService.GetBizCategory(bizId);
            return Ok(response);
        }

        [HttpPost("AddBizCategory")]
        public async Task<ActionResult<BizCategoryModel>> AddBizCategory([FromBody] CreateBizCategoryDto bizCategoryDto)
        {
            string user = User.FindFirstValue(ClaimTypes.Name);
            var response = await _bizCategoryCategoryService.AddBizCategory(bizCategoryDto, user);
            return CreatedAtAction(nameof(GetBizCategory), new { bizId = response.Id }, response);
        }

        [HttpDelete("DeleteBizCategory/{bizId}")]
        public async Task<IActionResult> DeleteBizCategory(Guid bizId)
        {
            await _bizCategoryCategoryService.DeleteBizCategory(bizId);
            return NoContent();
        }
    }
}
