using Cyon.Domain.Entities;
using Cyon.Domain.Models.Finance;

namespace Cyon.Domain.Repositories
{
    public interface IUserFinanceRepository : IRepository<UserFinance>
    {
        Task<UserFinanceSummary> GetUserFinanceSummary(Guid userId);
    }
}
