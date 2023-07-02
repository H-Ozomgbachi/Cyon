using Cyon.Domain.Common;
using Cyon.Domain.DTOs.UpcomngEvent;
using Cyon.Domain.Models.UpcomingEvent;

namespace Cyon.Domain.Services
{
    public interface IUpcomingEventService
    {
        Task<UpcomingEventModel> AddUpcomingEvent(CreateUpcomingEventDto upcomingEventDto, string modifiedBy);
        Task UpdateUpcomingEvent(UpdateUpcomingEventDto upcomingEventDto, string modifiedBy);
        Task DeleteUpcomingEvent(Guid upcomingEventId);
        Task<UpcomingEventModel> GetUpcomingEvent(Guid upcomingEventId);
        Task<IEnumerable<UpcomingEventModel>> GetUpcomingEvents(Pagination pagination);
    }
}
