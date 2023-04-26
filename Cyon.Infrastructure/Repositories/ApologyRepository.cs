using Cyon.Domain.Entities;
using Cyon.Domain.Models.Attendance;
using Cyon.Domain.Repositories;
using Cyon.Infrastructure.Database;
using Dapper;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Cyon.Infrastructure.Repositories
{
    public class ApologyRepository : Repository<Apology>, IApologyRepository
    {
        private readonly DapperContext _dapperContext;

        public ApologyRepository(DbSet<Apology> apologies, DapperContext dapperContext) : base(apologies)
        {
            _dapperContext = dapperContext;
        }

        public async Task<ApologySummary> GetApologySummary(string userId)
        {
            string sp1 = "Sp_GetApologySummary";
            var parameters = new DynamicParameters();
            parameters.Add("UserId", userId, DbType.String, ParameterDirection.Input);

            using var connection = _dapperContext.CreateConnection();

            var apologySummary = await connection.QueryFirstOrDefaultAsync<ApologySummary>(sp1, parameters, commandType: CommandType.StoredProcedure);

            return apologySummary;
        }
    }
}
