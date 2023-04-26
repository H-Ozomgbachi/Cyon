using Cyon.Domain.Common;
using Cyon.Domain.DTOs.Attendance;
using Cyon.Domain.Models.Attendance;
using Cyon.Domain.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Cyon.Api.Controllers.v1
{
    [Authorize]
    public class ApologyController : BaseController
    {
        private readonly IApologyService _apologyService;

        public ApologyController(IApologyService apologyService)
        {
            _apologyService = apologyService;
        }

        [HttpGet("GetUserApologies")]
        public async Task<ActionResult<IEnumerable<ApologyModel>>> GetUserApologies([FromQuery] Pagination pagination)
        {
            Guid userId = Guid.Parse(User.FindFirstValue(ClaimTypes.Name));
            return Ok(await _apologyService.GetApologiesByUser(userId, pagination));
        }

        [HttpGet("GetPendingApologies")]
        [Authorize(Roles = $"{Roles.Executive},{Roles.Super}")]
        public async Task<ActionResult<IEnumerable<ApologyModel>>> GetPendingApologies([FromQuery] Pagination pagination)
        {
            return Ok(await _apologyService.GetApologies(pagination, true));
        }

        [HttpPost("AddApology")]
        public async Task<ActionResult<ApologyModel>> AddApology(CreateApologyDto apologyDto)
        {
            Guid userId = Guid.Parse(User.FindFirstValue(ClaimTypes.Name));
            apologyDto.UserEmail = User.FindFirstValue(ClaimTypes.Email);
            var result = await _apologyService.AddApology(apologyDto, userId);
            return Ok(result);
        }

        [HttpDelete("DeleteApology/{apologyId}")]
        public async Task<IActionResult> DeleteApology(Guid apologyId)
        {
            await _apologyService.DeleteApology(apologyId);
            return NoContent();
        }

        [HttpPost("ApproveApology")]
        [Authorize(Roles = $"{Roles.Super},{Roles.Executive}")]
        public async Task<IActionResult> ApproveApology(ResolveApologyDto approveApologyDto)
        {
            await _apologyService.ApproveApology(approveApologyDto);
            return Ok();
        }

        [HttpPost("DeclineApology")]
        [Authorize(Roles = $"{Roles.Super},{Roles.Executive}")]
        public async Task<IActionResult> DeclineApology(ResolveApologyDto approveApologyDto)
        {
            await _apologyService.DeclineApology(approveApologyDto);
            return Ok();
        }

        [HttpGet("GetApologySummary")]
        public async Task<ActionResult<ApologySummaryModel>> GetApologySummary()
        {
            Guid userId = Guid.Parse(User.FindFirstValue(ClaimTypes.Name));
            return Ok(await _apologyService.GetApologySummary(userId));
        }
    }
}
