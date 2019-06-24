using System;
using System.Collections.Generic;
using System.Text;
using Instagram.Business.Model.Shared;

namespace Instagram.Business.Model.Post
{
    public class Post : BaseEntity
    {
        public string Description { get; set; }

        public string Image { get; set; }

        public User.ApplicationUser Author { get; set; }

        //public List<Like> Likes { get; set; }
    }
}
