using Cyon.Domain.Common;
using Cyon.Domain.DTOs.Decision;
using Cyon.Domain.Entities;
using Cyon.Domain.Models.Decision;
using Cyon.Domain.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Cyon.Api.Controllers.v1
{
    [Authorize]
    public class DecisionResponseController : BaseController
    {
        private readonly IDecisionResponseService _decisionResponseService;

        public DecisionResponseController(IDecisionResponseService decisionResponseService)
        {
            _decisionResponseService = decisionResponseService;
        }

        [HttpGet("GetDecisionResponses/{decisionId}")]
        public async Task<ActionResult<IEnumerable<DecisionResponseModel>>> GetDecisionResponses([FromQuery]Pagination pagination, Guid decisionId)
        {
            var response = await _decisionResponseService.GetDecisionResponses(decisionId, pagination);
            return Ok(response);
        }

        [HttpGet("GetMyDecisionResponse/{decisionId}")]
        public async Task<ActionResult<DecisionResponseModel>> GetMyDecisionResponse(Guid decisionId)
        {
            var response = await _decisionResponseService.GetMyDecisionResponse(decisionId, User.FindFirstValue(ClaimTypes.Actor));
            return Ok(response);
        }

        [HttpPost("AddDecisionResponse/")]
        public async Task<ActionResult<DecisionResponseModel>> AddDecisionResponse([FromBody]CreateDecisionResponseDto decisionResponseDto)
        {
            var response = await _decisionResponseService.AddDecisionResponse(decisionResponseDto, User.FindFirstValue(ClaimTypes.Actor));
            return CreatedAtAction(nameof(GetMyDecisionResponse), new { decisionId = response.DecisionId}, response);
        }
    }
}
