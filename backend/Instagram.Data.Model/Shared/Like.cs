using Instagram.Data.Model.Account;

namespace Instagram.Data.Model.Shared
{
    public class Like : BaseEntity
    {
        #region Navigation properties

        public int AuthorId { get; set; }
        public ApplicationUser Author { get; set; }

        public int? PostId { get; set; }
        public Post.Post Post { get; set; }

        public int? ReplyId { get; set; }
        public Reply.Reply Reply { get; set; }

        #endregion

    }
}
