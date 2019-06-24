using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Instagram.Data;
using Instagram.Data.Model.Account;
using Instagram.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Instagram.Repository.Implementations
{
    public class UserRepository : BaseRepository<ApplicationUser>, IUserRepository
    {
        public UserRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<ApplicationUser> GetUserByUsername(string username)
        {
            return await this.Context.Users.Where(p => p.UserName == username)
                .Include(p => p.Posts)
                .FirstOrDefaultAsync();
        }
    }
}
