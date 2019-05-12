using System.ComponentModel.DataAnnotations;
using Instagram.Business.Model.User;

namespace Instagram.WebApi.Models.Authentication
{
    public class RegisterModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Name { get; set; }

        public Gender Gender { get; set; }
    }
}
