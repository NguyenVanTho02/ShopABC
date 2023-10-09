using System;
using System.Collections.Generic;

namespace ShopABC.Entities
{
    public partial class ProductOrder
    {
        public int? Price { get; set; }
        public int? Quantity { get; set; }
        public int? Idorder { get; set; }
        public int? Idproduct { get; set; }

        public virtual Order? IdorderNavigation { get; set; }
        public virtual Product? IdproductNavigation { get; set; }
    }
}
