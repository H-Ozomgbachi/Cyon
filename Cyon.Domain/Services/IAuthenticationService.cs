using Cyon.Domain.DTOs.Authentication;
using Cyon.Domain.Models.Authentication;

namespace Cyon.Domain.Services
{
    public interface IAuthenticationService
    {
        Task<bool> ValidateUser(UserForAuthenticationDto userForAuthentication);
        Task<string> CreateToken();
        Task<AccountModel> MyAccount(Guid userId);
        Task ChangeRole(IEnumerable<string> roles, Guid userId);
    }
}
