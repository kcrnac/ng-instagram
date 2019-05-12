using System.Collections.Generic;
using Instagram.Data.Model.Account;
using Instagram.Data.Model.Shared;

namespace Instagram.Data.Model.Reply
{
    public class Reply : BaseEntity
    {
        public string Message { get; set; }


        #region Navigation properties

        public int? ParentId { get; set; }
        public Reply Parent { get; set; }

        public int AuthorId { get; set; }
        public ApplicationUser Author { get; set; }

        public List<Like> Likes { get; set; }

        #endregion
    }
}
