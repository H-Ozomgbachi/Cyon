using Cyon.Domain.DTOs.Authentication;
using Cyon.Domain.DTOs.Photos;
using Cyon.Domain.Models.Authentication;

namespace Cyon.Domain.Services
{
    public interface IAuthenticationService
    {
        Task<bool> ValidateUser(UserForAuthenticationDto userForAuthentication);
        Task<string> CreateToken();
        Task<AccountModel> MyAccount(Guid userId);
        Task ChangeRole(IEnumerable<string> roles, Guid userId);
        Task AddRolesToDb(IEnumerable<string> roles);
        Task<IEnumerable<AccountIdAWithEmail>> GetAccountIdsWithEmail(string searchKey);
    }
}
