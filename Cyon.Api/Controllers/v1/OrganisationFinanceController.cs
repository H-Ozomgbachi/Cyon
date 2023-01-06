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
    public class OrganisationFinanceController : BaseController
    {
        private readonly IOrganisationFinanceService _organisationFinanceService;

        public OrganisationFinanceController(IOrganisationFinanceService organisationFinanceService)
        {
            _organisationFinanceService = organisationFinanceService;
        }

        [HttpGet("GetOrganisationFinances")]
        public async Task<ActionResult<IEnumerable<OrganisationFinanceModel>>> GetOrganisationFinances([FromQuery]Pagination pagination)
        {
            var results = await _organisationFinanceService.GetOrganisationFinances(pagination);
            return Ok(results);
        }

        [HttpGet("GetOrganisationFinance/{id}")]
        public async Task<ActionResult<OrganisationFinanceModel>> GetOrganisationFinance(Guid id)
        {
            var result = await _organisationFinanceService.GetOrganisationFinance(id);
            return Ok(result);
        }

        [Authorize(Roles = Roles.Executive)]
        [HttpPost("AddOrganisationFinance")]
        public async Task<IActionResult> AddOrganisationFinance([FromBody] CreateOrganisationFinanceDto organisationFinanceDto)
        {
            Guid userId = Guid.Parse(User.FindFirstValue(ClaimTypes.Name));
            var result = await _organisationFinanceService.AddOrganisationFinance(organisationFinanceDto, userId);
            return CreatedAtAction(nameof(GetOrganisationFinance), new { id = result.Id }, result);
        }

        [Authorize(Roles = Roles.Executive)]
        [HttpPut("UpdateOrganisationFinance")]
        public async Task<IActionResult> UpdateOrganisationFinance([FromBody] UpdateOrganisationFinanceDto organisationFinanceDto)
        {
            Guid userId = Guid.Parse(User.FindFirstValue(ClaimTypes.Name));
            await _organisationFinanceService.UpdateOrganisationFinance(organisationFinanceDto, userId);
            return Ok();
        }

        [Authorize(Roles = Roles.Executive)]
        [HttpDelete("DeleteOrganisationFinance/{id}")]
        public async Task<IActionResult> DeleteOrganisationFinance(Guid id)
        {
            await _organisationFinanceService.DeleteOrganisationFinance(id);
            return NoContent();
        }

        [HttpGet("GetOrganisationFinanceBalance")]
        public async Task<IActionResult> GetOrganisationFinanceBalance()
        {
            var result = await _organisationFinanceService.GetOrganisationFinanceBalance();
            return Ok(new { balance = result });
        }

        [HttpPost("GetOrganisationAccountStatement")]
        public async Task<ActionResult<OrganisationAccountStatementModel>> GetOrganisationAccountStatement([FromBody] GetAccountStatementDto accountStatementDto)
        {
            var result = await _organisationFinanceService.GetOrganisationAccountStatement(accountStatementDto);
            return Ok(new { accountStatement = result });
        }
    }
}
