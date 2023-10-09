using System;
using System.Collections.Generic;

namespace ShopABC.Entities
{
    public partial class RegistrationUserToken
    {
        public int Idrutoken { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public string? Token { get; set; }
        public int? Iduser { get; set; }

        public virtual User? IduserNavigation { get; set; }
    }
}
