using Cyon.Domain.Common;
using Cyon.Domain.DTOs.Meeting;
using Cyon.Domain.Models.Meeting;
using Cyon.Domain.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Cyon.Api.Controllers.v1
{
    [Route("api/v1/meetings")]
    [ApiController]
    [Authorize]
    public class MeetingsController : ControllerBase
    {
        private readonly IMeetingService _meetingService;

        public MeetingsController(IMeetingService meetingService)
        {
            _meetingService = meetingService;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<MeetingModel>>> GetMeetings([FromQuery] Pagination pagination)
        {
            return Ok(await _meetingService.GetMeetings(pagination));
        }

        [HttpGet("{meetingId}")]
        public async Task<ActionResult<MeetingModel>> GetMeetingById(Guid meetingId)
        {
            return Ok(await _meetingService.GetMeeting(meetingId));
        }

        [HttpPost]
        [Authorize(Roles = $"{Roles.Executive}")]
        public async Task<IActionResult> AddMeeting([FromBody] CreateMeetingDto meetingDto)
        {
            Guid activeUserId = Guid.Parse(User.FindFirstValue(ClaimTypes.Name));
            var meeting = await _meetingService.AddMeeting(meetingDto, activeUserId);
            return CreatedAtAction(nameof(GetMeetingById), new { meetingId = meeting.Id }, meeting);
        }

        [HttpPut]
        [Authorize(Roles = $"{Roles.Executive}")]
        public async Task<IActionResult> UpdateMeeting([FromBody] UpdateMeetingDto meetingDto)
        {
            Guid activeUserId = Guid.Parse(User.FindFirstValue(ClaimTypes.Name));
            await _meetingService.UpdateMeeting(meetingDto, activeUserId);
            return Ok();
        }

        [HttpDelete("{meetingId}")]
        [Authorize(Roles = $"{Roles.Executive}")]
        public async Task<IActionResult> DeleteMeeting(Guid meetingId)
        {
            await _meetingService.DeleteMeeting(meetingId);
            return NoContent();
        }
    }
}
