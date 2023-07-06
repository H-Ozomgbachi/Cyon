using Cyon.Domain.Common;
using Cyon.Domain.DTOs.Finance;
using Cyon.Domain.Models.Finance;
using Cyon.Domain.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Cyon.Api.Controllers.v1
{
    [Authorize]
    public class UserFinanceController : BaseController
    {
        private readonly IUserFinanceService _userFinanceService;

        public UserFinanceController(IUserFinanceService userFinanceService)
        {
            _userFinanceService = userFinanceService;
        }

        [HttpGet("GetUserFinances")]
        public async Task<ActionResult<IEnumerable<UserFinanceModel>>> GetUserFinances([FromQuery]Pagination pagination)
        {
            Guid userId = Guid.Parse(User.FindFirstValue(ClaimTypes.Name));
            var result = await _userFinanceService.GetUserFinances(userId, pagination);
            return Ok(result);
        }

        [HttpGet("GetUserFinances/{id}")]
        public async Task<ActionResult<UserFinanceModel>> GetUserFinanceById(Guid id)
        {
            var result = await _userFinanceService.GetUserFinanceById(id);
            return Ok(result);
        }

        [HttpPost("AddUserFinance")]
        [Authorize(Roles = Roles.Executive)]
        public async Task<IActionResult> AddUserFinance([FromBody] CreateUserFinanceDto userFinanceDto)
        {
            Guid userId = Guid.Parse(User.FindFirstValue(ClaimTypes.Name));
            var result = await _userFinanceService.AddUserFinance(userFinanceDto, userId);
            return CreatedAtAction(nameof(GetUserFinanceById), new { id = result.Id }, result);
        }

        [HttpPut("UpdateUserFinance")]
        [Authorize(Roles = Roles.Executive)]
        public async Task<IActionResult> UpdateUserFinance([FromForm] UpdateUserFinanceDto userFinanceDto)
        {
            Guid userId = Guid.Parse(User.FindFirstValue(ClaimTypes.Name));
            await _userFinanceService.UpdateUserFinance(userFinanceDto, userId);
            return Ok();
        }

        [HttpDelete("DeleteUserFinance/{id}")]
        [Authorize(Roles = Roles.Executive)]
        public async Task<IActionResult> DeleteUserFinance(Guid id)
        {
            await _userFinanceService.DeleteUserFinance(id);
            return NoContent();
        }

        [HttpPost("PayDuesByAmount")]
        [Authorize(Roles = Roles.Executive)]
        public async Task<IActionResult> PayDuesByAmount([FromBody] PayDuesByAmountDto duesByAmountDto)
        {
            Guid userId = Guid.Parse(User.FindFirstValue(ClaimTypes.Name));
            await _userFinanceService.PayDuesByAmount(duesByAmountDto, userId);
            return Ok();
        }

        [HttpGet("GetUserFinanceSummary")]
        public async Task<ActionResult<UserFinanceSummary>> GetUserFinanceSummary()
        {
            Guid userId = Guid.Parse(User.FindFirstValue(ClaimTypes.Name));
            return Ok(await _userFinanceService.GetUserFinanceSummary(userId));
        }
    }
}
