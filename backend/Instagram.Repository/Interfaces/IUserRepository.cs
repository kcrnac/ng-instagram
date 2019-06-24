using System.Threading.Tasks;
using Instagram.Data.Model.Account;

namespace Instagram.Repository.Interfaces
{
    public interface IUserRepository : IAsyncRepository<ApplicationUser>
    {
        Task<ApplicationUser> GetUserByUsername(string username);
    }
}
