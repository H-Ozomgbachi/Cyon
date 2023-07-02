using Cyon.Domain.Common;
using Cyon.Domain.DTOs.Announcement;
using Cyon.Domain.Models.Announcement;

namespace Cyon.Domain.Services
{
    public interface IAnnouncementService
    {
        Task<AnnouncementModel> AddAnnouncement(CreateAnnouncementDto announcementDto, string modifiedBy);
        Task UpdateAnnouncement(UpdateAnnouncementDto announcementDto, string modifiedBy);
        Task DeleteAnnouncement(Guid announcementId);
        Task<AnnouncementModel> GetAnnouncement(Guid announcementId);
        Task<IEnumerable<AnnouncementModel>> GetAnnouncements(Pagination pagination);
        Task ReadAnnouncement(Guid announcementId, string readBy);
    }
}
