using AutoMapper;
using Cyon.Domain;
using Cyon.Domain.DTOs.AccountManagement;
using Cyon.Domain.DTOs.Photos;
using Cyon.Domain.Entities;
using Cyon.Domain.Exceptions;
using Cyon.Domain.Models.AccountManagement;
using Cyon.Domain.Models.Authentication;
using Cyon.Domain.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Cyon.Application.Services
{
    public class AccountManagementService : IAccountManagementService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;
        private readonly IPhotoService _photoService;

        public AccountManagementService(IUnitOfWork unitOfWork, UserManager<User> userManager, IMapper mapper, IPhotoService photoService)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
            _mapper = mapper;
            _photoService = photoService;
        }

        public async Task DeleteAccountDeactivationRequest(Guid id)
        {
            DeactivateRequest deactivateRequest = await _unitOfWork.DeactivateRequestRepository.GetByIdAsync(id);

            if (deactivateRequest == null)
            {
                throw new NotFoundException("Account deactivation request doesn't exist");
            }

            await _unitOfWork.DeactivateRequestRepository.DeleteAsync(deactivateRequest);
            await _unitOfWork.SaveAsync();
        }

        public async Task DeactivateAccount(DeactivateAccountDto deactivateAccountDto, Guid modifiedBy)
        {
            User user = await _userManager.FindByEmailAsync(deactivateAccountDto.UserEmail);
            if (user == null)
            {
                throw new NotFoundException("User account doesn't exist");
            }
            user.LastModified = DateTime.Now;
            user.ModifiedBy = modifiedBy;
            user.IsActive = false;
            user.InactiveReason = deactivateAccountDto.ReasonToDeactivate;

            await _userManager.UpdateAsync(user);
            await DeleteAccountDeactivationRequest(deactivateAccountDto.Id);
        }

        public async Task<IEnumerable<AccountDeactivateRequestModel>> GetAccountDeactivateRequests()
        {
            IEnumerable<DeactivateRequest> deactivateRequests = await _unitOfWork.DeactivateRequestRepository.GetAllAsync();

            return _mapper.Map<IEnumerable<AccountDeactivateRequestModel>>(deactivateRequests);
        }

        public async Task RequestToDeactivate(RequestToDeactivateDto requestToDeactivate)
        {
            var user = await _userManager.FindByIdAsync(requestToDeactivate.UserId.ToString());
            if (user == null)
            {
                throw new NotFoundException("User account doesn't exist");
            }

            if ((await _unitOfWork.DeactivateRequestRepository.ExistAsync(x => x.UserId == user.Id)))
            {
                throw new BadRequestException("You already have a pending request");
            }

            DeactivateRequest deactivateRequest = new()
            {
                UserId = user.Id,
                UserName = user.UserName,
                UserEmail = user.Email,
                ReasonToDeactivate = requestToDeactivate.Reason,
                Phone = user.PhoneNumber
            };
            await _unitOfWork.DeactivateRequestRepository.AddAsync(deactivateRequest);
            await _unitOfWork.SaveAsync();
        }

        public async Task<int> GetNumberOfActiveUsers()
        {
            return await _userManager.Users.CountAsync(x => x.IsActive == true);
        }

        public async Task<IEnumerable<GroupedUsersModel>> GenerateRandomUserGroups(GenerateRandomUserGroupsDto randomUserGroupsDto)
        {
            var users = await _userManager.Users.Where(x => x.IsActive).ToListAsync();

            List<GroupedUsersModel> groups = new();

            for (int i = 0; i < randomUserGroupsDto.GroupTitles.Count(); i++)
            {
                List<User> formedUsers = new();
                Random rnd = new();

                if (users.Count < randomUserGroupsDto.NumberOfUsersPerGroup)
                {
                    formedUsers = users;
                }
                else
                {
                    for (int j = 0; j < randomUserGroupsDto.NumberOfUsersPerGroup; j++)
                    {
                        var temp = rnd.Next(0, users.Count);
                        formedUsers.Add(users.ElementAt(temp));
                        users.RemoveAt(temp);
                    }
                }

                var resultingGroup = new GroupedUsersModel
                {
                    GroupTitle = randomUserGroupsDto.GroupTitles.ElementAt(i),
                    Members = _mapper.Map<IEnumerable<AccountModel>>(formedUsers)
                };

                groups.Add(resultingGroup);
            }

            return groups;
        }


        public async Task UploadProfilePicture(PictureDto pictureDto, Guid userId)
        {
            string imgUrl = await _photoService.UploadProfilePicture(pictureDto);

            if (string.IsNullOrEmpty(imgUrl))
            {
                throw new BadRequestException("Problem uploading image");
            }

            var user = await _userManager.FindByIdAsync(userId.ToString());
            user.ModifiedBy = userId; user.LastModified = DateTime.UtcNow; user.PhotoUrl = imgUrl;
            await _userManager.UpdateAsync(user);
        }
    }
}
