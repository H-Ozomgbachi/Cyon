using Cyon.Domain.Entities;
using Cyon.Domain.Models.Attendance;

namespace Cyon.Domain.Repositories
{
    public interface IAttendanceRegisterRepository : IRepository<AttendanceRegister>
    {
        Task<AttendanceSummary> GetAttendanceSummary(string userId);
    }
}
