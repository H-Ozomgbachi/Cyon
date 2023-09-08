using Cyon.Domain.Entities;
using Cyon.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Cyon.Infrastructure.Repositories
{
    public class BizProductRepository : Repository<BizProduct>, IBizProductRepository
    {
        public BizProductRepository(DbSet<BizProduct> entities) : base(entities)
        {
        }
    }
}
