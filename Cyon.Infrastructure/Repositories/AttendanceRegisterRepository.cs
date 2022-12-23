using Cyon.Domain.Entities;
using Cyon.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Cyon.Infrastructure.Repositories
{
    public class AttendanceRegisterRepository : Repository<AttendanceRegister>, IAttendanceRegisterRepository
    {
        public AttendanceRegisterRepository(DbSet<AttendanceRegister> attendanceRegisters) : base(attendanceRegisters)
        {
        }
    }
}
