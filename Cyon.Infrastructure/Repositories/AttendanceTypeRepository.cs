using Cyon.Domain.Entities;
using Cyon.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Cyon.Infrastructure.Repositories
{
    public class AttendanceTypeRepository : Repository<AttendanceType>, IAttendanceTypeRepository
    {
        public AttendanceTypeRepository(DbSet<AttendanceType> attendanceTypes) : base(attendanceTypes)
        {
        }
    }
}
