namespace Instagram.Repository.Model
{
    public class Account : BaseEntity
    {
        public ApplicationUser User { get; set; }

        public Settings.Settings Settings { get; set; }
    }
}
