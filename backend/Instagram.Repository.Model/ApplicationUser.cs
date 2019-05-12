using Microsoft.AspNetCore.Identity;

namespace Instagram.Repository.Model
{
    public class ApplicationUser : IdentityUser<int>
    {
        public string ProfilePictureUrl { get; set; }
    }
}
