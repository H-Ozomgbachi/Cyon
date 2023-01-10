using Cyon.Domain.Common;
using Cyon.Domain.DTOs.Occupation;
using Cyon.Domain.Models.Authentication;
using Cyon.Domain.Models.Occupation;
using Cyon.Domain.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Cyon.Api.Controllers.v1
{
    [Authorize]
    public class OccupationsController : BaseController
    {
        private readonly IOccupationService _occupationService;

        public OccupationsController(IOccupationService occupationService)
        {
            _occupationService = occupationService;
        }

        [HttpGet("GetOccupations")]
        [Authorize(Roles = $"{Roles.Executive},{Roles.Super}")]
        public async Task<ActionResult<IEnumerable<OccupationModel>>> GetOccupations([FromQuery] Pagination pagination)
        {
            var occupations = await _occupationService.GetOccupations(pagination);
            return Ok(occupations);
        }

        [HttpGet("GetOccupationByUser")]
        public async Task<ActionResult<OccupationModel>> GetOccupationByUser()
        {
            Guid activeUserId = Guid.Parse(User.FindFirstValue(ClaimTypes.Name));
            var occupation = await _occupationService.GetOccupationByUser(activeUserId);
            return Ok(occupation);
        }

        [HttpPost("AddOccupation")]
        public async Task<IActionResult> AddOccupation([FromBody] CreateOccupationDto occupationDto)
        {
            Guid activeUserId = Guid.Parse(User.FindFirstValue(ClaimTypes.Name));
            var occupation = await _occupationService.AddOccupation(occupationDto, activeUserId);
            return CreatedAtAction(nameof(GetOccupationByUser), new { occupationId = occupation.Id }, occupation);
        }

        [HttpPut("UpdateOccupation")]
        public async Task<IActionResult> UpdateOccupation([FromBody] UpdateOccupationDto occupationDto)
        {
            await _occupationService.UpdateOccupation(occupationDto);
            return Ok();
        }

        [HttpGet("PeopleWithSimilarOccupation/{jobKeyWord}")]
        public async Task<ActionResult<IEnumerable<AccountModelConcise>>> PeopleWithSimilarOccupation([FromQuery] Pagination pagination, string jobKeyWord)
        {
            Guid activeUserId = Guid.Parse(User.FindFirstValue(ClaimTypes.Name));
            var result = await _occupationService.PeopleWithSimilarOccupation(jobKeyWord, pagination, activeUserId);
            return Ok(result);
        }
    }
}
