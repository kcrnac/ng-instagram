using Instagram.Data;
using Instagram.Data.Model.Account;
using Instagram.Repository.Interfaces;

namespace Instagram.Repository.Implementations
{
    public class AccountRepository : BaseRepository<Account>, IAccountRepository
    {
        public AccountRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
