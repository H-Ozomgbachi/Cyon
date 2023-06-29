using Cyon.Domain.Common;
using Cyon.Domain.DTOs.Minutes;
using Cyon.Domain.Models.Minutes;

namespace Cyon.Domain.Services
{
    public interface IMinutesService
    {
        Task<MinutesModel> AddMinute(CreateMinuteDto minuteDto, Guid modifiedBy);
        Task DeleteMinute(Guid minuteId);
        Task<MinutesModel> GetMinute(Guid minuteId);
        Task<IEnumerable<MinutesModel>> GetMinutes(Pagination pagination);
        Task<IEnumerable<MinutesModel>> GetMinuteByMeetingDate(DateTime date);
    }
}
