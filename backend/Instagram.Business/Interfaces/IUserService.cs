using System.Threading.Tasks;
using Instagram.Business.Model.User;
using Microsoft.AspNetCore.Identity;

namespace Instagram.Business.Interfaces
{
    public interface IUserService
    {
        Task<IdentityResult> Register(ApplicationUser user);
    }
}
