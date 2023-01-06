using Cyon.Domain.Common;
using Cyon.Domain.DTOs.Minutes;
using Cyon.Domain.Models.Minutes;
using Cyon.Domain.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Cyon.Api.Controllers.v1
{
    [Route("api/v1/minutes")]
    [Authorize]
    [ApiController]
    public class MinutesController : ControllerBase
    {
        private readonly IMinutesService _minutesService;

        public MinutesController(IMinutesService minutesService)
        {
            _minutesService = minutesService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MinutesModel>>> GetAllMinutes([FromQuery] Pagination pagination)
        {
            return Ok(await _minutesService.GetMinutes(pagination));
        }

        [HttpGet("{minuteId}", Name = "GetMinuteById")]
        public async Task<ActionResult<MinutesModel>> GetMinuteById(Guid minuteId)
        {
            return Ok(await _minutesService.GetMinute(minuteId));
        }

        [HttpPost]
        [Authorize(Roles = $"{Roles.Executive}")]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        public async Task<IActionResult> AddMinute([FromBody] CreateMinuteDto createMinuteDto)
        {
            Guid activeUserId = Guid.Parse(User.FindFirstValue(ClaimTypes.Name));
            var minutes = await _minutesService.AddMinute(createMinuteDto, activeUserId);
            return CreatedAtAction(nameof(GetMinuteById), new { minuteId = minutes.Id }, minutes);
        }

        [HttpPut]
        [Authorize(Roles = $"{Roles.Executive}")]
        public async Task<IActionResult> UpdateMinute([FromBody] UpdateMinuteDto updateMinuteDto)
        {
            Guid activeUserId = Guid.Parse(User.FindFirstValue(ClaimTypes.Name));
            await _minutesService.UpdateMinute(updateMinuteDto, activeUserId);
            return Ok();
        }

        [HttpDelete("{minuteId}")]
        [Authorize(Roles = $"{Roles.Executive}")]
        public async Task<IActionResult> DeleteMinute(Guid minuteId)
        {
            await _minutesService.DeleteMinute(minuteId);
            return NoContent();
        }
    }
}
