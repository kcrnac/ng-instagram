using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Instagram.Business.Interfaces;
using Instagram.Business.Mappers;
using Instagram.Business.Model.ServiceResult;
using Instagram.Business.Model.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Instagram.Business.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<Data.Model.Account.ApplicationUser> _userManager;
        private readonly IConfiguration _configuration;

        public UserService(UserManager<Data.Model.Account.ApplicationUser> userManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;
        }
        public async Task<IdentityResult> Register(ApplicationUser user)
        {
            try
            {
                return await _userManager.CreateAsync(user.MapToDataModel(), user.Password);
            }
            catch (Exception e)
            {
                // TODO: Implement logger
                throw e;
            }
        }

        public async Task<ServiceResult<string>> Login(string username, string password)
        {
            var result = new ServiceResult<string>();

            var user = await _userManager.FindByNameAsync(username);

            if (user != null && await _userManager.CheckPasswordAsync(user, password))
            {
                var role = await _userManager.GetRolesAsync(user);
                var identityOptions = new IdentityOptions();
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim("UserId", user.Id.ToString())
                    }),
                    Expires = DateTime.UtcNow.AddMinutes(30),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["ApplicationSettings:JwtSecret"])), SecurityAlgorithms.HmacSha256Signature)
                };

                var tokenHandler = new JwtSecurityTokenHandler();
                var securityToken = tokenHandler.CreateToken(tokenDescriptor);
                var token = tokenHandler.WriteToken(securityToken);

                result.Result = token;
            }
            else
            {
                result.Errors.Add(new ValidationError
                {
                    Name = "Invalid Credentials",
                    Message = "Username or password is invalid"
                });
            }

            return result;
        }
    }
}
