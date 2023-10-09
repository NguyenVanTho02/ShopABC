using System;
using System.Collections.Generic;

namespace ShopABC.Entities
{
    public partial class Cart
    {
        public int Idcart { get; set; }
        public int? Iduser { get; set; }

        public virtual User? IduserNavigation { get; set; }
    }
}
