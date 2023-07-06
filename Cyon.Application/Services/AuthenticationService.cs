using AutoMapper;
using Cyon.Domain.DTOs.Authentication;
using Cyon.Domain.DTOs.Photos;
using Cyon.Domain.Entities;
using Cyon.Domain.Exceptions;
using Cyon.Domain.Models.Authentication;
using Cyon.Domain.Services;
using Cyon.Infrastructure.Database;
using Microsoft.AspNetCore.Identity;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
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
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly AppDbContext _dbContext;
        private User? _user;

        public AuthenticationService(UserManager<User> userManager, IConfiguration config, IMapper mapper, IDepartmentService departmentService, RoleManager<IdentityRole> roleManager, AppDbContext dbContext)
        {
            _userManager = userManager;
            _config = config;
            _mapper = mapper;
            _departmentService = departmentService;
            _roleManager = roleManager;
            _dbContext = dbContext;
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
            List<Claim> claims = new()
            {
                new Claim(ClaimTypes.Name, _user.Id),
                new Claim(ClaimTypes.Email, _user.Email),
                new Claim(ClaimTypes.Actor, _user.UniqueCode)
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
            if (_user != null)
            {
                _user.LastLogin = DateTime.Now;
                await _userManager.UpdateAsync(_user);
            }
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

        public async Task AddRolesToDb(IEnumerable<string> roles)
        {
            foreach (var role in roles)
            {
                string formattedRole = FormatString(role);

                if (await _roleManager.RoleExistsAsync(formattedRole))
                {
                    continue;
                }
                
                await _roleManager.CreateAsync(new IdentityRole()
                {
                    Name = formattedRole,
                    NormalizedName = formattedRole.ToUpper(),
                }) ;
            }
        }

        private static string FormatString(string rawString)
        {
            char[] letters = rawString.ToCharArray();

            List<string> final = new();

            for (int i = 0; i < letters.Length; i++)
            {
                var refined = letters[i].ToString().Trim().ToLower();
                if (i == 0)
                {
                    final.Add(refined.ToUpper());
                }
                else
                {
                    final.Add(refined);
                }
            }
            return string.Join(string.Empty, final);
        }

        public async Task<IEnumerable<AccountIdAWithEmail>> GetAccountIdsWithEmail(string searchKey)
        {
            HashSet<AccountIdAWithEmail> accountIdAWithEmails = new();

            var users = await _dbContext.Users.FromSqlRaw("Sp_GetAccountIdsWithEmail @SearchKey", 
                new SqlParameter("@SearchKey", searchKey)
                ).ToListAsync();

            foreach (var item in users)
            {
                AccountIdAWithEmail accountIdAWithEmail = new()
                {
                    UserId = Guid.Parse(item.Id),
                    UserEmail = item.Email
                };
                accountIdAWithEmails.Add(accountIdAWithEmail);
            }
            return accountIdAWithEmails;
        }

        public Task<AccountModel> UploadProfilePicture(PictureDto profilePictureDto, Guid userId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<AccountModel>> GetAllUsers()
        {
            var user = await _userManager.Users.Where(x => x.IsActive).ToListAsync();
            return _mapper.Map<IEnumerable<AccountModel>>(user);
        }

        public async Task<bool> UpdateMyAccount(UserForUpdateDto userForUpdateDto, Guid modifiedBy)
        {
            var user = await _userManager.FindByIdAsync(userForUpdateDto.Id);

            if (user == null)
            {
                throw new NotFoundException("User doesn't exist or is deleted");
            }
            var userToUpdate = _mapper.Map(userForUpdateDto, user);
            userToUpdate.ModifiedBy = modifiedBy; userToUpdate.LastModified = DateTime.UtcNow;

            var result = await _userManager.UpdateAsync(userToUpdate);
            return result.Succeeded;
        }

        public async Task<string> GenerateUniqueId()
        {
            int num = await _userManager.Users.Where(x => x.DateAdded.Year == DateTime.Now.Year).CountAsync();
            string year = DateTime.Now.Year.ToString()[2..];

            return $"CYS{year}{(num + 1).ToString().PadLeft(3, '0')}";
        }
    }
}
