using Cyon.Domain.Entities;
using Cyon.Domain.Models.Finance;

namespace Cyon.Domain.Repositories
{
    public interface IOrganisationFinanceRepository : IRepository<OrganisationFinance>
    {
        Task<decimal> GetOrganisationFinanceBalance();
        Task<OrganisationAccountStatementModel> GetStatementOfAccount(DateTime startDate, DateTime endDate);
        Task<OrganizationAccountBalance> GetOrganizationAccountBalance();
    }
}
