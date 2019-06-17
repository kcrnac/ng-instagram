using System.Security.Claims;
using System.Threading.Tasks;
using Instagram.Business.Model.User;
using Microsoft.AspNetCore.Identity;

namespace Instagram.Business.Interfaces
{
    public interface IUserService
    {
        Task<IdentityResult> Register(ApplicationUser user);
        Task<string> Login(string username, string password);
        Task<ApplicationUser> GetUserById(string userId);
        Task<ApplicationUser> GetUserByUsername(string username);
    }
}
