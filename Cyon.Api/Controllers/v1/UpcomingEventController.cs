using Cyon.Domain.Common;
using Cyon.Domain.DTOs.UpcomngEvent;
using Cyon.Domain.Models.UpcomingEvent;
using Cyon.Domain.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Cyon.Api.Controllers.v1
{
    [Authorize]
    public class UpcomingEventController : BaseController
    {
        private readonly IUpcomingEventService _upcomingEventService;

        public UpcomingEventController(IUpcomingEventService upcomingEventService)
        {
            _upcomingEventService = upcomingEventService;
        }

        [HttpGet("GetUpcomingEvents")]
        public async Task<ActionResult<IEnumerable<UpcomingEventModel>>> GetUpcomingEvents([FromQuery] Pagination pagination)
        {
            var result = await _upcomingEventService.GetUpcomingEvents(pagination);
            return Ok(result);
        }

        [HttpGet("GetUpcomingEvent/{upcomingEventId}")]
        public async Task<ActionResult<UpcomingEventModel>> GetUpcomingEvent(Guid upcomingEventId)
        {
            var upcomingEvent = await _upcomingEventService.GetUpcomingEvent(upcomingEventId);
            return Ok(upcomingEvent);
        }

        [HttpPost("AddUpcomingEvent")]
        public async Task<ActionResult<UpcomingEventModel>> AddUpcomingEvent([FromForm] CreateUpcomingEventDto upcomingEventDto)
        {
            string user = User.FindFirstValue(ClaimTypes.Actor);
            var upcomingEvent = await _upcomingEventService.AddUpcomingEvent(upcomingEventDto, user);
            return CreatedAtAction(nameof(GetUpcomingEvent), new { upcomingEventId = upcomingEvent.Id }, upcomingEvent);
        }

        [HttpPut("UpdateUpcomingEvent")]
        public async Task<IActionResult> UpdateUpcomingEvent([FromForm] UpdateUpcomingEventDto upcomingEventDto)
        {
            string user = User.FindFirstValue(ClaimTypes.Actor);
            await _upcomingEventService.UpdateUpcomingEvent(upcomingEventDto, user);
            return Ok();
        }

        [HttpDelete("DeleteUpcomingEvent/{upcomingEventId}")]
        public async Task<IActionResult> DeleteUpcomingEvent(Guid upcomingEventId)
        {
            await _upcomingEventService.DeleteUpcomingEvent(upcomingEventId);
            return NoContent();
        }
    }
}
