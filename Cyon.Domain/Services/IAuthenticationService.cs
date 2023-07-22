using Cyon.Domain.DTOs.Authentication;
using Cyon.Domain.Entities;
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
        Task<bool> UpdateMyAccount(UserForUpdateDto userForUpdateDto, Guid modifiedBy);
        Task<string> GenerateUniqueId();
        Task<IEnumerable<AccountModel>> GetAllUsers();
        Task SendPasswordResetMail(User user, string token);
        Task<string> ResetPassword(ResetPasswordDto resetPasswordDto);
        Task SendConfirmEmailMessage(string email);
        Task ConfirmEmail(string email, string passcode);
    }
}
