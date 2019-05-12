using System;
using System.Threading.Tasks;
using Instagram.Business.Interfaces;
using Instagram.Business.Mappers;
using Instagram.Business.Model.User;
using Microsoft.AspNetCore.Identity;

namespace Instagram.Business.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<Data.Model.Account.ApplicationUser> _userManager;

        public UserService(UserManager<Data.Model.Account.ApplicationUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task<IdentityResult> Register(ApplicationUser user)
        {
            try
            {
                return await _userManager.CreateAsync(user.MapToDataModel(), user.Password);
            }
            catch(Exception e)
            {
                // Implement logger
                throw e;
            }
        }
    }
}
