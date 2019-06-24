using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Ardalis.GuardClauses;
using AutoMapper;
using Instagram.Business.Constants;
using Instagram.Business.Exceptions;
using Instagram.Business.Interfaces;
using Instagram.Business.Mappers;
using Instagram.Common.Constants;
using Instagram.Common.ErrorHandling.Exceptions;
using Instagram.Common.Logger.Interfaces;
using Instagram.Data.Model.Account;
using Instagram.Data.Model.Post;
using Instagram.Repository.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ApplicationUser = Instagram.Business.Model.User.ApplicationUser;

namespace Instagram.Business.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<Data.Model.Account.ApplicationUser> _userManager;
        private readonly IConfiguration _configuration;
        private readonly ILoggerService _loggerService;
        private readonly IAccountRepository _accountRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(
            ILoggerService loggerService, 
            UserManager<Data.Model.Account.ApplicationUser> userManager, 
            IConfiguration configuration,
            IAccountRepository accountRepository,
            IUserRepository userRepository,
            IMapper mapper)
        {
            _userManager = userManager;
            _configuration = configuration;
            _loggerService = loggerService;
            _accountRepository = accountRepository;
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public async Task<IdentityResult> Register(ApplicationUser user)
        {
            try
            {
                var result = await _userManager.CreateAsync(user.MapToDataModel(_mapper), user.Password);

                if (result.Succeeded)
                {
                    var dbUser = await _userRepository.GetUserByUsername(user.Username);

                    if (dbUser != null)
                    {
                        dbUser.Posts = new List<Post>()
                        {
                            new Post() { Description = "First post" }
                        };

                        dbUser.Accounts = new List<Account>()
                        {
                            new Account() { DateCreated = DateTime.Now,  Owner = dbUser }
                        };

                        await _userRepository.Update(dbUser);
                    }
                }

                return result;
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
                        new Claim(ClaimTypes.Name, user.Id.ToString())
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

        public async Task<ApplicationUser> GetUserById(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);

            return user.MapToBusinessModel(_mapper);
        }

        public async Task<ApplicationUser> GetUserByUsername(string username)
        {
            var user = await _userRepository.GetUserByUsername(username);

            return user.MapToBusinessModel(_mapper);
        }
    }
}
