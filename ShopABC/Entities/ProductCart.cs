using System;
using System.Collections.Generic;

namespace ShopABC.Entities
{
    public partial class ProductCart
    {
        public int? Idcart { get; set; }
        public int? Idproduct { get; set; }
        public int? Quantity { get; set; }
    }
}
