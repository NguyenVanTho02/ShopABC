using System;
using System.Collections.Generic;

namespace ShopABC.Entities
{
    public partial class Product
    {
        public int Idproduct { get; set; }
        public string? AgeGroup { get; set; }
        public string? Describle { get; set; }
        public string? Guide { get; set; }
        public string? Image { get; set; }
        public string? Info { get; set; }
        public string? Name { get; set; }
        public int? Price { get; set; }
        public int? Quantity { get; set; }
        public string? Status { get; set; }
        public int? Idbrand { get; set; }
        public int? Idcategory { get; set; }
        public int? Idpromotion { get; set; }

        public virtual Brand? IdbrandNavigation { get; set; }
        public virtual Category? IdcategoryNavigation { get; set; }
        public virtual Promotion? IdpromotionNavigation { get; set; }
    }
}
