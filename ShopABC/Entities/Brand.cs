using System;
using System.Collections.Generic;

namespace ShopABC.Entities
{
    public partial class Brand
    {
        public Brand()
        {
            Products = new HashSet<Product>();
        }

        public int Idbrand { get; set; }
        public string NameBrand { get; set; } = null!;

        public virtual ICollection<Product> Products { get; set; }
    }
}
