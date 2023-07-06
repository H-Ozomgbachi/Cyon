using Cyon.Domain.Entities;
using Cyon.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Cyon.Infrastructure.Repositories
{
    public class DecisionResponseRepository : Repository<DecisionResponse>, IDecisionResponseRepository
    {
        public DecisionResponseRepository(DbSet<DecisionResponse> decisionResponses) : base(decisionResponses)
        {
        }
    }
}
