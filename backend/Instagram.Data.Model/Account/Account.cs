using Instagram.Data.Model.Shared;

namespace Instagram.Data.Model.Account
{
    public class Account : BaseEntity
    {
        #region Navigation properties

        public int OwnerId { get; set; }
        public ApplicationUser Owner { get; set; }

        public Settings Settings { get; set; }

        #endregion
    }
}
