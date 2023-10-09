using System;
using System.Collections.Generic;

namespace ShopABC.Entities
{
    public partial class Order
    {
        public int Idorder { get; set; }
        public DateTime? CreatedTime { get; set; }
        public string? OrderStatus { get; set; }
        public string? PaymentMethod { get; set; }
        public string? PaymentStatus { get; set; }
        public int? Idship { get; set; }
        public int? Iduser { get; set; }

        public virtual Shipping? IdshipNavigation { get; set; }
        public virtual User? IduserNavigation { get; set; }
    }
}
