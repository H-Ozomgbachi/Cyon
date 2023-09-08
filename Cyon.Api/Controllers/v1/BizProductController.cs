using Cyon.Domain.Common;
using Cyon.Domain.DTOs.Biz;
using Cyon.Domain.Models.Biz;
using Cyon.Domain.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Cyon.Api.Controllers.v1
{
    public class BizProductController : BaseController
    {
        private readonly IBizProductService _bizProductService;

        public BizProductController(IBizProductService bizProductService)
        {
            _bizProductService = bizProductService;
        }

        [HttpGet("{bizId}/GetBizProducts/")]
        public async Task<ActionResult<IEnumerable<BizProductModel>>> GetBizProducts(Pagination pagination, Guid bizId)
        {
            var response = await _bizProductService.GetBizProducts(pagination, bizId);
            return Ok(response);
        }

        [HttpGet("GetBizProduct/{bizProductId}")]
        public async Task<ActionResult<BizProductModel>> GetBizProduct(Guid bizProductId)
        {
            var response = await _bizProductService.GetBizProduct(bizProductId);
            return Ok(response);
        }

        [Authorize]
        [HttpPost("CreateBizProduct/")]
        public async Task<ActionResult<BizProductModel>> CreateBizProduct([FromBody]CreateBizProductDto createBizProductDto)
        {
            string userId = User.FindFirstValue(ClaimTypes.Name);
            var response = await _bizProductService.CreateBizProduct(createBizProductDto, userId);
            return CreatedAtAction(nameof(GetBizProduct), new { bizProductId = response.Id}, response);
        }

        [Authorize]
        [HttpPut("UpdateBizProduct/")]
        public async Task<IActionResult> UpdateBizProduct([FromBody]UpdateBizProductDto updateBizProductDto)
        {
            string userId = User.FindFirstValue(ClaimTypes.Name);
            await _bizProductService.UpdateBizProduct(updateBizProductDto,userId);
            return NoContent();
        }

        [HttpDelete("DeleteBizProduct/{bizProductId}")]
        public async Task<IActionResult> DeleteBizProduct(Guid bizProductId)
        {
            await _bizProductService.DeleteBizProduct(bizProductId);
            return NoContent();
        }
    }
}
