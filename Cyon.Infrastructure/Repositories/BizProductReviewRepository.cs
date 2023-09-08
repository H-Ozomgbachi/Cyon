using Cyon.Domain.Entities;
using Cyon.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Cyon.Infrastructure.Repositories
{
    public class BizProductReviewRepository : Repository<BizProductReview>, IBizProductReviewRepository
    {
        public BizProductReviewRepository(DbSet<BizProductReview> entities) : base(entities)
        {
        }
    }
}
