using Cyon.Domain.Entities;
using Cyon.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Cyon.Infrastructure.Repositories
{
    public class DeactivateRequestRepository : Repository<DeactivateRequest>, IDeactivateRequestRepository
    {
        public DeactivateRequestRepository(DbSet<DeactivateRequest> deactivateRequests) : base(deactivateRequests)
        {
        }
    }
}
