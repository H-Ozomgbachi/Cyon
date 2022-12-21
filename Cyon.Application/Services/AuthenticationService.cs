using AutoMapper;
using Cyon.Domain.DTOs.Authentication;
using Cyon.Domain.Entities;
using Cyon.Domain.Exceptions;
using Cyon.Domain.Models.Authentication;
using Cyon.Domain.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Cyon.Application.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly UserManager<User> _userManager;
        private readonly IConfiguration _config;
        private readonly IMapper _mapper;
        private readonly IDepartmentService _departmentService;
        private User? _user;

        public AuthenticationService(UserManager<User> userManager, IConfiguration config, IMapper mapper, IDepartmentService departmentService)
        {
            _userManager = userManager;
            _config = config;
            _mapper = mapper;
            _departmentService = departmentService;
        }

        public async Task<string> CreateToken()
        {
            JwtSecurityTokenHandler tokenHandler = new();
            SigningCredentials signingCredentials = GetSigningCredentials();
            List<Claim> claims = await GetClaims();
            SecurityTokenDescriptor tokenOptions = GenerateTokenOptions(signingCredentials, claims);

            var token = tokenHandler.CreateToken(tokenOptions);
            return tokenHandler.WriteToken(token);
        }

        private SecurityTokenDescriptor GenerateTokenOptions(SigningCredentials signingCredentials, List<Claim> claims)
        {
            var tokenOptions = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Issuer = _config["JwtSettings:ValidIssuer"],
                Audience = _config["JwtSettings:ValidAudience"],
                Expires = DateTime.Now.AddMinutes(Convert.ToInt32(_config["JwtSettings:Expires"])),
                SigningCredentials = signingCredentials
            };
            return tokenOptions;
        }

        private SigningCredentials GetSigningCredentials()
        {
            var key = Encoding.UTF8.GetBytes(_config["JwtSettings:SecretKey"]);
            var secret = new SymmetricSecurityKey(key);
            return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256Signature);
        }

        private async Task<List<Claim>> GetClaims()
        {
            List<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, _user.Id),
                new Claim(ClaimTypes.Email, _user.Email),
            };

            var roles = await _userManager.GetRolesAsync(_user);
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            return claims;
        }

        public async Task<bool> ValidateUser(UserForAuthenticationDto userForAuthentication)
        {
            _user = await _userManager.FindByEmailAsync(userForAuthentication.Email);
            return (_user != null && await _userManager.CheckPasswordAsync(user: _user, userForAuthentication.Password));
        }

        public async Task<AccountModel> MyAccount(Guid userId)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());

            if (user == null)
            {
                throw new NotFoundException("User doesn't exist or is deleted");
            }

            IList<string> roles = await _userManager.GetRolesAsync(user);
            var department = await _departmentService.GetDepartmentByIdAsync(user.DepartmentId);

            if (department == null)
            {
                throw new NotFoundException("Invalid department id was provided");
            }

            AccountModel userModel = _mapper.Map<AccountModel>(user);
            userModel.Roles = roles; userModel.Department = department;
            return userModel;

        }

        public async Task ChangeRole(IEnumerable<string> roles, Guid userId)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());

            if (user == null)
            {
                throw new NotFoundException("User doesn't exist or is deleted");
            }

            await _userManager.AddToRolesAsync(user, roles);
        }
    }
}
