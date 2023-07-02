using Cyon.Domain.DTOs.AccountManagement;
using Cyon.Domain.DTOs.Photos;
using Cyon.Domain.Models.AccountManagement;

namespace Cyon.Domain.Services
{
    public interface IAccountManagementService
    {
        Task RequestToDeactivate(RequestToDeactivateDto requestToDeactivate);
        Task<IEnumerable<AccountDeactivateRequestModel>> GetAccountDeactivateRequests();
        Task DeactivateAccount(DeactivateAccountDto deactivateAccountDto, Guid modifiedBy);
        Task DeleteAccountDeactivationRequest(Guid id);
        Task<int> GetNumberOfActiveUsers();
        Task<IEnumerable<GroupedUsersModel>> GenerateRandomUserGroups(GenerateRandomUserGroupsDto randomUserGroupsDto);
        Task UploadProfilePicture(PictureDto pictureDto, Guid userId);

    }
}
