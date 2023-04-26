using Cyon.Domain.Common;
using Cyon.Domain.Entities;
using Cyon.Domain.Models.Attendance;
using Cyon.Domain.Repositories;
using Cyon.Infrastructure.Database;
using Dapper;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Cyon.Infrastructure.Repositories
{
    public class AttendanceRegisterRepository : Repository<AttendanceRegister>, IAttendanceRegisterRepository
    {
        private readonly DapperContext _dapperContext;

        public AttendanceRegisterRepository(DbSet<AttendanceRegister> attendanceRegisters, DapperContext dapperContext) : base(attendanceRegisters)
        {
            _dapperContext = dapperContext;
        }

        public async Task<AttendanceSummary> GetAttendanceSummary(string userId)
        {
            string sp1 = "Sp_GetAttendanceSummary";
            var parameters = new DynamicParameters();
            parameters.Add("UserId", userId, DbType.String, ParameterDirection.Input);

            using var connection = _dapperContext.CreateConnection();

            var attendanceSummary = await connection.QueryFirstOrDefaultAsync<AttendanceSummary>(sp1, parameters, commandType:CommandType.StoredProcedure);

            return attendanceSummary;
        }
    }
}
