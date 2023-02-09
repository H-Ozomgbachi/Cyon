using Cyon.Application.Services;
using Cyon.Domain.Common;
using Cyon.Domain.DTOs.Announcement;
using Cyon.Domain.Models.Announcement;
using Cyon.Domain.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Cyon.Api.Controllers.v1
{
    [Route("api/v1/announcement")]
    [ApiController]
    [Authorize]
    public class AnnouncementsController : ControllerBase
    {
        private readonly IAnnouncementService _announcementService;

        public AnnouncementsController(IAnnouncementService announcementService)
        {
            _announcementService = announcementService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AnnouncementModel>>> GetAnnouncements([FromQuery]Pagination pagination)
        {
            return Ok(await _announcementService.GetAnnouncements(pagination));
        }

        [HttpGet("{announcementId}")]
        public async Task<ActionResult<AnnouncementModel>> GetAnnouncement(Guid announcementId)
        {
            return Ok(await _announcementService.GetAnnouncement(announcementId));
        }

        [HttpPost]
        public async Task<IActionResult> AddAnnouncement([FromForm] CreateAnnouncementDto announcementDto)
        {
            Guid activeUserId = Guid.Parse(User.FindFirstValue(ClaimTypes.Name));
            var announcement = await _announcementService.AddAnnouncement(announcementDto, activeUserId);
            return CreatedAtAction(nameof(GetAnnouncement), new { announcementId = announcement.Id }, announcement);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAnnouncement([FromBody] UpdateAnnouncementDto announcementDto)
        {
            Guid activeUserId = Guid.Parse(User.FindFirstValue(ClaimTypes.Name));
            await _announcementService.UpdateAnnouncement(announcementDto, activeUserId);
            return Ok();
        }

        [HttpDelete("{announcementId}")]
        public async Task<IActionResult> DeleteAnnouncement(Guid announcementId)
        {
            await _announcementService.DeleteAnnouncement(announcementId);
            return NoContent();
        }
    }
}
