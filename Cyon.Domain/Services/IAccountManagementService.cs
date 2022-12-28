using Cyon.Domain.DTOs.AccountManagement;
using Cyon.Domain.Models.AccountManagement;

namespace Cyon.Domain.Services
{
    public interface IAccountManagementService
    {
        Task RequestToDeactivate(RequestToDeactivateDto requestToDeactivate);
        Task<IEnumerable<AccountDeactivateRequestModel>> GetAccountDeactivateRequests();
        Task DeactivateAccount(DeactivateAccountDto deactivateAccountDto, Guid modifiedBy);
        Task DeleteAccountDeactivationRequest(Guid id);
    }
}
