using AutoMapper;
using Cyon.Domain.Common;
using Cyon.Domain.DTOs.Authentication;
using Cyon.Domain.DTOs.Photos;
using Cyon.Domain.Entities;
using Cyon.Domain.Models.Authentication;
using Cyon.Domain.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Cyon.Api.Controllers.v1
{
    [Route("api/v1/authentication")]
    [ApiController]
    [Authorize]
    public class AuthenticationController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly IAuthenticationService _authenticationService;

        public AuthenticationController(IMapper mapper, UserManager<User> userManager, IAuthenticationService authenticationService)
        {
            _mapper = mapper;
            _userManager = userManager;
            _authenticationService = authenticationService;
        }
        [HttpPost("register")]
        [AllowAnonymous]
        public async Task<IActionResult> RegisterUser([FromBody] UserForRegistrationDto userForRegistrationDto)
        {
            var user = _mapper.Map<User>(userForRegistrationDto);
            user.LastModified = DateTime.Now;
            user.ModifiedBy = Guid.Parse(user.Id);
            
            var result = await _userManager.CreateAsync(user, userForRegistrationDto.Password);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.TryAddModelError(error.Code, error.Description);
                }
                return BadRequest(ModelState);
            }
            await _userManager.AddToRolesAsync(user, new List<string> { "Member"});

            return StatusCode(201);
        }
        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> LoginUser([FromBody] UserForAuthenticationDto userForAuthenticationDto)
        {
            if (!(await _authenticationService.ValidateUser(userForAuthenticationDto)))
            {
                return Unauthorized();
            }
            return Ok(new {Message = "Login successful", Token = await _authenticationService.CreateToken()});
        }

        [HttpGet("account")]
        public async Task<ActionResult<AccountModel>> GetAccount()
        {
            Guid activeUserId = Guid.Parse(User.FindFirstValue(ClaimTypes.Name));
            return Ok(await _authenticationService.MyAccount(activeUserId));
        }

        [HttpPost("account/{id}/change-role")]
        [Authorize(Roles = $"{Roles.Super},{Roles.Executive}")]
        public async Task<IActionResult> ChangeRole(Guid id, [FromBody] IEnumerable<string> roles)
        {
            await _authenticationService.ChangeRole(roles, id);
            return StatusCode(201);
        }
        [HttpPost("create-roles")]
        public async Task<IActionResult> CreateRoles([FromBody] IEnumerable<string> roles)
        {
            await _authenticationService.AddRolesToDb(roles);
            return Ok();
        }

        [HttpGet("get-users-email-and-id")]
        public async Task<ActionResult> GetUsersEmailAndId([FromQuery]string startsWith = "a")
        {
            return Ok(await _authenticationService.GetAccountIdsWithEmail(startsWith));
        }

        [HttpPost("forgot-password")]
        [AllowAnonymous]
        public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordDto forgotPasswordDto)
        {
            var user = await _userManager.FindByEmailAsync(forgotPasswordDto.Email);
            if (user == null)
            {
                return NotFound(new {message = $"User with email: {forgotPasswordDto.Email} not found"});
            }
            var token = await _userManager.GeneratePasswordResetTokenAsync(user);

            // TODO: Send and email to continue with password reset.
            
            return Ok(new {resetToken = token });
        }

        [HttpPost("reset-password")]
        [AllowAnonymous]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordDto resetPasswordDto)
        {
            return Ok();
        }
    }
}
