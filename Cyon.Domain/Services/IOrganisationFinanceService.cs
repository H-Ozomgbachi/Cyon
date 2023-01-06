using Cyon.Domain.Common;
using Cyon.Domain.DTOs.Finance;
using Cyon.Domain.Models.Finance;

namespace Cyon.Domain.Services
{
    public interface IOrganisationFinanceService
    {
        Task<IEnumerable<OrganisationFinanceModel>> GetOrganisationFinances(Pagination pagination);
        Task<OrganisationFinanceModel> GetOrganisationFinance(Guid id);
        Task<OrganisationFinanceModel> AddOrganisationFinance(CreateOrganisationFinanceDto organisationFinanceDto, Guid modifiedBy);
        Task UpdateOrganisationFinance(UpdateOrganisationFinanceDto organisationFinanceDto, Guid modifiedBy);
        Task DeleteOrganisationFinance(Guid id);
        Task<decimal> GetOrganisationFinanceBalance();
        Task<OrganisationAccountStatementModel> GetOrganisationAccountStatement(GetAccountStatementDto accountStatementDto);
    }
}
