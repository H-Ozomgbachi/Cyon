using Cyon.Domain.Common;
using Cyon.Domain.DTOs.Biz;
using Cyon.Domain.Models.Biz;
using Cyon.Domain.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Cyon.Api.Controllers.v1
{
    [Authorize]
    public class BizController : BaseController
    {
        private readonly IBizService _bizService;

        public BizController(IBizService bizService)
        {
            _bizService = bizService;
        }

        [HttpGet("GetBizs")]
        public async Task<ActionResult<IEnumerable<BizModel>>> GetBizs([FromQuery]Pagination pagination)
        {
            var response = await _bizService.GetBizs(pagination);
            return Ok(response);
        }

        [HttpGet("GetBiz/{bizId}", Name = "GetBiz")]
        public async Task<ActionResult<BizModel>> GetBiz(Guid bizId)
        {
            var response = await _bizService.GetBiz(bizId);
            return Ok(response);
        }

        [HttpPost("AddBiz")]
        public async Task<ActionResult<BizModel>> AddBiz([FromBody] CreateBizDto createBizDto)
        {
            string user = User.FindFirstValue(ClaimTypes.Name);
            var response = await _bizService.AddBiz(createBizDto, user);
            return CreatedAtAction(nameof(GetBiz), new { bizId = response.Id }, response);
        }

        [HttpPut("UpdateBiz")]
        public async Task<IActionResult> UpdateBiz([FromBody] UpdateBizDto updateBizDto)
        {
            string user = User.FindFirstValue(ClaimTypes.Name);
            await _bizService.UpdateBiz(updateBizDto, user);
            return NoContent();
        }

        [HttpDelete("DeleteBiz/{bizId}")]
        public async Task<IActionResult> DeleteBiz(Guid bizId)
        {
            await _bizService.DeleteBiz(bizId);
            return NoContent();
        }
    }
}
