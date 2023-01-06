using Cyon.Domain.Common;
using Cyon.Domain.DTOs.Attendance;
using Cyon.Domain.Models.Attendance;

namespace Cyon.Domain.Services
{
    public interface IAttendanceRegisterService
    {
        Task CollectAttendance(CollectAttendanceDto collectAttendanceDto);
        Task<IEnumerable<AttendanceRegisterModel>> GetCurrentDayAttendance(Pagination pagination);
        Task<IEnumerable<AttendanceRegisterModel>> GetMyAttendanceRecord(Guid userId, Pagination pagination);
        Task<string> MarkAbsent(MarkAbsentDto markAbsentDto);
    }
}
