using System;
using Instagram.Business.Model.Shared;

namespace Instagram.Business.Model.User
{
    public class ApplicationUser : BaseEntity
    {
        public string Username { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string Name { get; set; }

        public Gender Gender { get; set; }

        public DateTime Birthday { get; set; }
    }
}
