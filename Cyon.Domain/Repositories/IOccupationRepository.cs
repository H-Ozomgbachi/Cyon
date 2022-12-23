using Cyon.Domain.Entities;

namespace Cyon.Domain.Repositories
{
    public interface IOccupationRepository : IRepository<Occupation>
    {
        Task<Occupation> GetOccupationByUserId(Guid userId);
    }
}
