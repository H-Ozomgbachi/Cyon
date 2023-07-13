using Cyon.Domain.Common;
using Cyon.Domain.DTOs.Attendance;
using Cyon.Domain.Models.Attendance;

namespace Cyon.Domain.Services
{
    public interface IAttendanceRegisterService
    {
        Task CollectAttendance(CollectAttendanceDto collectAttendanceDto, string userCode);
        Task<IEnumerable<AttendanceRecordModel>> GetAttendanceRecord(AttendanceRecordDto attendanceRecordDto);
        Task<IEnumerable<AttendanceRegisterModel>> GetMyAttendanceRecord(string userCode, Pagination pagination);
        Task<string> MarkAbsent(MarkAbsentDto markAbsentDto, string userCode);
        Task<AttendanceSummaryModel> GetAttendanceSummary(string userCode);
    }
}
