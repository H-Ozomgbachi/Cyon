using Cyon.Domain.Common;
using Cyon.Domain.DTOs.Attendance;
using Cyon.Domain.Models.Attendance;

namespace Cyon.Domain.Services
{
    public interface IAttendanceTypeService
    {
        Task<AttendanceTypeModel> AddAttendanceType(CreateAttendanceTypeDto attendanceTypeDto);
        Task<AttendanceTypeModel> GetAttendanceType(Guid attendanceTypeId);
        Task<IEnumerable<AttendanceTypeModel>> GetAttendanceTypes(Pagination pagination);
        Task UpdateAttendanceType(UpdateAttendanceTypeDto attendanceTypeDto);
        Task DeleteAttendanceType(Guid attendanceTypeId);
    }
}
