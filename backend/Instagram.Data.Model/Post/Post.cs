using System.Collections.Generic;
using Instagram.Data.Model.Account;
using Instagram.Data.Model.Shared;

namespace Instagram.Data.Model.Post
{
    public class Post : BaseEntity
    {
        public string Description { get; set; }

        #region Navigation properties

        public int AuthorId { get; set; }
        public ApplicationUser Author { get; set; }

        public List<Like> Likes { get; set; }

        #endregion
    }
}
