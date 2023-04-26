using Cyon.Domain.Entities;
using Cyon.Domain.Models.Finance;
using Cyon.Domain.Repositories;
using Cyon.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace Cyon.Infrastructure.Repositories
{
    public class UserFinanceRepository : Repository<UserFinance>, IUserFinanceRepository
    {
        private readonly DapperContext _dapperContext;

        public UserFinanceRepository(DbSet<UserFinance> userFinances, DapperContext dapperContext) : base(userFinances)
        {
            _dapperContext = dapperContext;
        }

        public async Task<UserFinanceSummary> GetUserFinanceSummary(string userId)
        {
            throw new NotImplementedException();
        }
    }
}
