using Cyon.Domain.Entities;
using Cyon.Domain.Models.Finance;
using Cyon.Domain.Repositories;
using Cyon.Infrastructure.Database;
using Dapper;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Cyon.Infrastructure.Repositories
{
    public class UserFinanceRepository : Repository<UserFinance>, IUserFinanceRepository
    {
        private readonly DapperContext _dapperContext;

        public UserFinanceRepository(DbSet<UserFinance> userFinances, DapperContext dapperContext) : base(userFinances)
        {
            _dapperContext = dapperContext;
        }

        public async Task<UserFinanceSummary> GetUserFinanceSummary(Guid userId)
        {
            string sp = "Sp_GetUserFinanceSummary";

            var parameters1 = new DynamicParameters();
            parameters1.Add("UserId", userId, DbType.Guid, ParameterDirection.Input);

            using (var connection = _dapperContext.CreateConnection())
            {
                var result = await connection.QueryFirstOrDefaultAsync<UserFinanceSummary>(sp, parameters1, commandType: CommandType.StoredProcedure);

                return result;
            }
        }
    }
}
