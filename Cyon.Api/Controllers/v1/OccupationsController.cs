using Cyon.Domain.Common;
using Cyon.Domain.DTOs.Occupation;
using Cyon.Domain.Models.Occupation;
using Cyon.Domain.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Cyon.Api.Controllers.v1
{
    [Route("api/v1/occupations")]
    [ApiController]
    [Authorize]
    public class OccupationsController : ControllerBase
    {
        private readonly IOccupationService _occupationService;

        public OccupationsController(IOccupationService occupationService)
        {
            _occupationService = occupationService;
        }

        [HttpGet]
        [Authorize(Roles = $"{Roles.Executive},{Roles.Super}")]
        public async Task<ActionResult<IEnumerable<OccupationModel>>> GetOccupations([FromQuery] Pagination pagination)
        {
            var occupations = await _occupationService.GetOccupations(pagination);
            return Ok(occupations);
        }

        [HttpGet("get-user-occupation")]
        public async Task<ActionResult<OccupationModel>> GetOccupation()
        {
            Guid activeUserId = Guid.Parse(User.FindFirstValue(ClaimTypes.Name));
            var occupation = await _occupationService.GetOccupationByUser(activeUserId);
            return Ok(occupation);
        }

        [HttpPost]
        public async Task<IActionResult> AddOccupation([FromBody] CreateOccupationDto occupationDto)
        {
            Guid activeUserId = Guid.Parse(User.FindFirstValue(ClaimTypes.Name));
            var occupation = await _occupationService.AddOccupation(occupationDto, activeUserId);
            return CreatedAtAction(nameof(GetOccupation), new { occupationId = occupation.Id }, occupation);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateOccupation([FromBody] UpdateOccupationDto occupationDto)
        {
            await _occupationService.UpdateOccupation(occupationDto);
            return Ok();
        }
    }
}
