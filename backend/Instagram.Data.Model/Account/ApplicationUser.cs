using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace Instagram.Data.Model.Account
{
    public class ApplicationUser : IdentityUser<int>
    {
        public string Name { get; set; }
        public string ProfilePictureUrl { get; set; }
        public DateTime Birthdate { get; set; }
        public Gender Gender { get; set; }

        #region Navigation properties

        public List<Account> Accounts { get; set; }

        #endregion
    }
}
