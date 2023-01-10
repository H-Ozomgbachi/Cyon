using Cyon.Domain.Common;
using Cyon.Domain.Entities;

namespace Cyon.Domain.Repositories
{
    public interface IOccupationRepository : IRepository<Occupation>
    {
        Task<Occupation> GetOccupationByUserId(Guid userId);
        Task<IEnumerable<Occupation>> PeopleWithSimilarOccupation(string jobKeyWord, Pagination pagination, Guid userId);
    }
}
