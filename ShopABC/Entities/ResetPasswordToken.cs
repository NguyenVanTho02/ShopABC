using System;
using System.Collections.Generic;

namespace ShopABC.Entities
{
    public partial class ResetPasswordToken
    {
        public int Idrptoken { get; set; }
        public DateTime ExpiryDate { get; set; }
        public string Token { get; set; } = null!;
        public int? Iduser { get; set; }

        public virtual User? IduserNavigation { get; set; }
    }
}
