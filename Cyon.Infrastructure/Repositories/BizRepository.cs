using Cyon.Domain.Entities;
using Cyon.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Cyon.Infrastructure.Repositories
{
    public class BizRepository : Repository<Biz>, IBizRepository
    {
        public BizRepository(DbSet<Biz> bizs) : base(bizs)
        {
        }
    }
}