﻿using System;

namespace Instagram.Business.Model.Shared
{
    public class BaseEntity
    {
        public int Id { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime? DateModified { get; set; }
    }
}
