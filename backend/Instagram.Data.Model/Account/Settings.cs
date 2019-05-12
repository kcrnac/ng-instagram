using Instagram.Data.Model.Shared;

namespace Instagram.Data.Model.Account
{
    public class Settings : BaseEntity
    {
        #region Navigation properties

        public int PrivacyId { get; set; }
        public Privacy Privacy { get; set; }

        public int AccountId { get; set; }
        public Account Account { get; set; }

        #endregion
    }
}
