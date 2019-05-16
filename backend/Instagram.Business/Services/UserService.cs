using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Ardalis.GuardClauses;
using Instagram.Business.Constants;
using Instagram.Business.Exceptions;
using Instagram.Business.Interfaces;
using Instagram.Business.Mappers;
using Instagram.Business.Model.User;
using Instagram.Common.Constants;
using Instagram.Common.ErrorHandling.Exceptions;
using Instagram.Common.Logger.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Instagram.Business.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<Data.Model.Account.ApplicationUser> _userManager;
        private readonly IConfiguration _configuration;
        private readonly ILoggerService _loggerService;

        public UserService(ILoggerService loggerService, UserManager<Data.Model.Account.ApplicationUser> userManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;
            _loggerService = loggerService;
        }
        public async Task<IdentityResult> Register(ApplicationUser user)
        {
            try
            {
                return await _userManager.CreateAsync(user.MapToDataModel(), user.Password);
            }
            catch (Exception e)
            {
                _loggerService.LogError(e.Message);

                throw new Exception(e.Message);
            }
        }

        public async Task<string> Login(string username, string password)
        {
            var user = await _userManager.FindByNameAsync(username);

            Guard.Against.UsernameDoesNotExist(user);

            if (await _userManager.CheckPasswordAsync(user, password))
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
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration[ConfigurationConstants.JwtSecretKey])), SecurityAlgorithms.HmacSha256Signature)
                };

                var tokenHandler = new JwtSecurityTokenHandler();
                var securityToken = tokenHandler.CreateToken(tokenDescriptor);
                var token = tokenHandler.WriteToken(securityToken);

                return token;
            }
            else
            {
                throw new ValidationException(ValidationConstants.IncorrectPassword);
            }
        }
    }
}
