using Cyon.Domain.Entities;
using Cyon.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Cyon.Infrastructure.Repositories
{
    public class BizCategoryRepository : Repository<BizCategory>, IBizCategoryRepository
    {
        public BizCategoryRepository(DbSet<BizCategory> bizCategories) : base(bizCategories)
        {
        }
    }
}
