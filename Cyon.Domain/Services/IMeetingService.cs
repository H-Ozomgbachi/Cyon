using Cyon.Domain.Common;
using Cyon.Domain.DTOs.Meeting;
using Cyon.Domain.Models.Meeting;

namespace Cyon.Domain.Services
{
    public interface IMeetingService
    {
        Task<MeetingModel> AddMeeting(CreateMeetingDto meetingDto, Guid modifiedBy);
        Task<MeetingModel> GetMeeting(Guid meetingId);
        Task<IEnumerable<MeetingModel>> GetMeetings(Pagination pagination);
        Task UpdateMeeting(UpdateMeetingDto meetingDto, Guid modifiedBy);
        Task DeleteMeeting(Guid meetingId);
    }
}
