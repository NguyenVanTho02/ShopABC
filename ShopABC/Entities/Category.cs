using System;
using System.Collections.Generic;

namespace ShopABC.Entities
{
    public partial class Category
    {
        public Category()
        {
            Products = new HashSet<Product>();
        }

        public int Idcategory { get; set; }
        public string NameCategory { get; set; } = null!;

        public virtual ICollection<Product> Products { get; set; }
    }
}
