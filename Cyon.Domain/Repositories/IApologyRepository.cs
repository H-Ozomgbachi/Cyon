using Cyon.Domain.Entities;
using Cyon.Domain.Models.Attendance;

namespace Cyon.Domain.Repositories
{
    public interface IApologyRepository : IRepository<Apology>
    {
        Task<ApologySummary> GetApologySummary(string userId);
    }
}
