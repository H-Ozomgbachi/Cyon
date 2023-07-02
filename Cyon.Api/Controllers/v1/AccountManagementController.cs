using Cyon.Domain.Common;
using Cyon.Domain.DTOs.AccountManagement;
using Cyon.Domain.DTOs.Photos;
using Cyon.Domain.Models.AccountManagement;
using Cyon.Domain.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Cyon.Api.Controllers.v1
{
    [Authorize]
    public class AccountManagementController : BaseController
    {
        private readonly IAccountManagementService _accountManagementService;

        public AccountManagementController(IAccountManagementService accountManagementService)
        {
            _accountManagementService = accountManagementService;
        }

        [HttpPost("RequestToDeactivateAccount")]
        public async Task<IActionResult> RequestToDeactivateAccount([FromBody] RequestToDeactivateDto requestToDeactivateDto)
        {
            Guid userId = Guid.Parse(User.FindFirstValue(ClaimTypes.Name));
            requestToDeactivateDto.UserId = userId;
            await _accountManagementService.RequestToDeactivate(requestToDeactivateDto);
            return Ok();
        }

        [HttpGet("GetAccountDeactivateRequests")]
        [Authorize(Roles = $"{Roles.Executive},{Roles.Super}")]
        public async Task<ActionResult<IEnumerable<AccountDeactivateRequestModel>>> GetAccountDeactivateRequests()
        {
            return Ok(await _accountManagementService.GetAccountDeactivateRequests());
        }

        [HttpPost("DeactivateAccount")]
        public async Task<IActionResult> DeactivateAccount([FromBody] DeactivateAccountDto deactivateAccountDto)
        {
            Guid userId = Guid.Parse(User.FindFirstValue(ClaimTypes.Name));
            await _accountManagementService.DeactivateAccount(deactivateAccountDto, userId);
            return Ok();
        }

        [HttpGet("GetNumberOfActiveUsers")]
        public async Task<IActionResult> GetNumberOfActiveUsers()
        {
            var result = await _accountManagementService.GetNumberOfActiveUsers();
            return Ok(new {numberOfActiveUsers = result});
        }

        [HttpPost("GenerateRandomUserGroups")]
        public async Task<ActionResult<IEnumerable<GroupedUsersModel>>> GenerateRandomUserGroups(GenerateRandomUserGroupsDto randomUserGroupsDto)
        {
            var results = await _accountManagementService.GenerateRandomUserGroups(randomUserGroupsDto);
            return Ok(results);
        }

        [HttpPost("UploadProfilePicture")]
        public async Task<IActionResult> UploadProfilePicture([FromForm] PictureDto pictureDto)
        {
            Guid userId = Guid.Parse(User.FindFirstValue(ClaimTypes.Name));
            await _accountManagementService.UploadProfilePicture(pictureDto, userId);
            return Ok();
        }
    }
}
