using Cyon.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace Cyon.Api.Controllers.v1
{
    public class NotificationsController : BaseController
    {
        private readonly INotificationsService _notificationsService;

        public NotificationsController(INotificationsService notificationsService)
        {
            _notificationsService = notificationsService;
        }

        [HttpPost("SendWelcomeMessages")]
        public async Task<IActionResult> SendWelcomeMessages()
        {
            await _notificationsService.SendWelcomeNotification();
            return Ok();
        }

        [HttpPost("SendAnnouncementReminder/{announcementId}")]
        public async Task<IActionResult> SendAnnouncementReminder(Guid announcementId)
        {
            await _notificationsService.SendAnnouncementReminder(announcementId);
            return Ok();
        }

        [HttpPost("SendBirthdayWishes")]
        public async Task<IActionResult> SendBirthdayWishes()
        {
            await _notificationsService.SendBirthdayWishes();
            return Ok();
        }
    }
}
