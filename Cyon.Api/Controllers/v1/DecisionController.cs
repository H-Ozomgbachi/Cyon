using Cyon.Domain.Common;
using Cyon.Domain.DTOs.Decision;
using Cyon.Domain.Models.Decision;
using Cyon.Domain.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Cyon.Api.Controllers.v1
{
    [Authorize]
    public class DecisionController : BaseController
    {
        private readonly IDecisionService _decisionService;

        public DecisionController(IDecisionService decisionService)
        {
            _decisionService = decisionService;
        }

        [HttpGet("GetDecisions/")]
        public async Task<ActionResult<IEnumerable<DecisionModel>>> GetDecisions([FromQuery]Pagination pagination)
        {
            var response = await _decisionService.GetDecisions(pagination);
            return Ok(response);
        }

        [HttpGet("GetDecision/{decisionId}")]
        public async Task<ActionResult<DecisionModel>> GetDecision(Guid decisionId)
        {
            var response = await _decisionService.GetDecision(decisionId);
            return Ok(response);
        }

        [HttpPost("AddDecision/")]
        public async Task<ActionResult<DecisionModel>> AddDecision([FromBody]CreateDecisionDto decisionDto)
        {
            string userCode = User.FindFirstValue(ClaimTypes.Actor);
            var response = await _decisionService.AddDecision(decisionDto, userCode);

            return CreatedAtAction(nameof(GetDecision), new { decisionId = response.Id }, response);
        }

        [HttpPut("UpdateDecision/")]
        public async Task<IActionResult> UpdateDecision([FromBody]UpdateDecisionDto updateDecisionDto)
        {
            string userCode = User.FindFirstValue(ClaimTypes.Actor);
            await _decisionService.UpdateDecision(updateDecisionDto, userCode);
            return Ok();
        }

        [HttpDelete("DeleteDecision/{decisionId}")]
        public async Task<IActionResult> DeleteDecision(Guid decisionId)
        {
            await _decisionService.DeleteDecision(decisionId);
            return NoContent();
        }
    }
}
