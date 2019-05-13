using System.ComponentModel.DataAnnotations;

namespace Instagram.WebApi.Models.Authentication
{
    public class LoginModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
