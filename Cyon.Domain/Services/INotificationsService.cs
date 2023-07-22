namespace Cyon.Domain.Services
{
    public interface INotificationsService
    {
        Task SendWelcomeNotification();
        Task SendBirthdayWishes();
        Task SendAnnouncementReminder(Guid announcementId);
        Task SendUpcomingEventReminder();
    }
}
