using Cyon.Domain.Entities;
using Cyon.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Cyon.Infrastructure.Repositories
{
    public class BizProductTransactionRepository : Repository<BizProductTransaction>, IBizProductTransactionRepository
    {
        public BizProductTransactionRepository(DbSet<BizProductTransaction> entities) : base(entities)
        {
        }
    }
}
