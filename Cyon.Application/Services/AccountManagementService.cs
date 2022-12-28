using AutoMapper;
using Cyon.Domain;
using Cyon.Domain.DTOs.AccountManagement;
using Cyon.Domain.Entities;
using Cyon.Domain.Exceptions;
using Cyon.Domain.Models.AccountManagement;
using Cyon.Domain.Services;
using Microsoft.AspNetCore.Identity;

namespace Cyon.Application.Services
{
    public class AccountManagementService : IAccountManagementService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;

        public AccountManagementService(IUnitOfWork unitOfWork, UserManager<User> userManager, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
            _mapper = mapper;
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
    }
}
