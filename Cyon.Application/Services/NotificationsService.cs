using Cyon.Domain;
using Cyon.Domain.Entities;
using Cyon.Domain.Exceptions;
using Cyon.Domain.Repositories;
using Cyon.Domain.Services;
using Cyon.Infrastructure.EmailManager;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace Cyon.Application.Services
{
    public class NotificationsService : INotificationsService
    {
        private readonly UserManager<User> _userManager;
        private readonly IEmailSender _emailSender;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUtilityRepository _utilityRepository;

        public NotificationsService(UserManager<User> userManager, IEmailSender emailSender, IUnitOfWork unitOfWork, IUtilityRepository utilityRepository)
        {
            _userManager = userManager;
            _emailSender = emailSender;
            _unitOfWork = unitOfWork;
            _utilityRepository = utilityRepository;
        }

        public async Task SendWelcomeNotification()
        {
            // Get all unwelcomed members
            var unwelcomedUsers = await _userManager.Users.Where(x => x.IsWelcomed == false).ToListAsync();

            // Loop and send welcome email
            foreach (var user in unwelcomedUsers)
            {
                string content = _utilityRepository.LoadEmailTemplate("welcome_msg.html");
                StringBuilder sb = new(content);
                sb.Replace("[UserName]", $"{user.FirstName}");

                var message = new Message(new string[] { user.Email }, "We're Glad You Signed Up!", sb.ToString(), null);

                await _emailSender.SendEmail(message);

                user.IsWelcomed = true;
                var result = await _userManager.UpdateAsync(user);
                if (!result.Succeeded)
                {
                    throw new BadRequestException($"Encountered and error while trying to update {user.UserName}");
                }
            }
        }

        public async Task SendBirthdayWishes()
        {
            // Get all celebrants
            var celebrants = await _userManager.Users.Where(x => x.DateOfBirth.Day == DateTime.UtcNow.Day && x.DateOfBirth.Month == DateTime.UtcNow.Month).ToListAsync();

            // Loop and send email
            foreach (var user in celebrants)
            {
                string content = _utilityRepository.LoadEmailTemplate("birthday.html");
                StringBuilder sb = new(content);
                sb.Replace("[UserName]", $"{user.FirstName}");

                var message = new Message(new string[] { user.Email }, "It's Your Special Day!", sb.ToString(), null);

                await _emailSender.SendEmail(message);
            }
        }

        public async Task SendAnnouncementReminder(Guid announcementId)
        {
            var announcement = await _unitOfWork.AnnouncementRepository.GetByIdAsync(announcementId);

            if (announcement == null)
            {
                throw new NotFoundException("Announcement might have been deleted");
            }
            var activeUsers = await _userManager.Users.Where(x => x.IsActive == true).ToListAsync();

            foreach (var user in activeUsers)
            {
                string content = _utilityRepository.LoadEmailTemplate("announce.html");
                StringBuilder sb = new(content);

                sb.Replace("[Title]", announcement.Title);
                sb.Replace("[Content]", announcement.Content);
                sb.Replace("[UserName]", user.FirstName);
                var message = new Message(new string[] {user.Email}, "Reminder: Important Announcement ", sb.ToString(), null);

                await _emailSender.SendEmail(message);
            }
        }

        public Task SendUpcomingEventReminder()
        {
            throw new NotImplementedException();
        }
    }
}
