using System;
using System.Collections.Generic;

namespace ShopABC.Entities
{
    public partial class Promotion
    {
        public Promotion()
        {
            Products = new HashSet<Product>();
        }

        public int Idpromotion { get; set; }
        public string? Code { get; set; }
        public int? Value { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
