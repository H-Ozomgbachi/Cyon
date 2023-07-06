using Cyon.Domain.Entities;
using Cyon.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Cyon.Infrastructure.Repositories
{
    public class DecisionRepository : Repository<Decision>, IDecisionRepository
    {
        public DecisionRepository(DbSet<Decision> decisions) : base(decisions)
        {
        }
    }
}
