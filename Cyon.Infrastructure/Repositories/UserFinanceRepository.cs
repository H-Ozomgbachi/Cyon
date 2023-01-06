using Cyon.Domain.Entities;
using Cyon.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Cyon.Infrastructure.Repositories
{
    public class UserFinanceRepository : Repository<UserFinance>, IUserFinanceRepository
    {
        public UserFinanceRepository(DbSet<UserFinance> userFinances) : base(userFinances)
        {
        }
    }
}
