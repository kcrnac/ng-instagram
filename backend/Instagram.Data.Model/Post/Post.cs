using System.Collections.Generic;
using Instagram.Data.Model.Account;
using Instagram.Data.Model.Shared;

namespace Instagram.Data.Model.Post
{
    public class Post : BaseEntity
    {
        public string Description { get; set; }

        public string Image { get; set; }

        #region Navigation properties

        public ApplicationUser Author { get; set; }

        public ICollection<Like> Likes { get; set; }

        #endregion
    }
}
