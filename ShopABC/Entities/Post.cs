using System;
using System.Collections.Generic;

namespace ShopABC.Entities
{
    public partial class Post
    {
        public int Idpost { get; set; }
        public string? ContentPost { get; set; }
        public DateTime? CreatedTime { get; set; }
        public string? Title { get; set; }
        public int? Iduser { get; set; }

        public virtual User? IduserNavigation { get; set; }
    }
}
