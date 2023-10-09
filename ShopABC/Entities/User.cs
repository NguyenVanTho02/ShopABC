using System;
using System.Collections.Generic;

namespace ShopABC.Entities
{
    public partial class User
    {
        public User()
        {
            Carts = new HashSet<Cart>();
            Orders = new HashSet<Order>();
            Posts = new HashSet<Post>();
            RegistrationUserTokens = new HashSet<RegistrationUserToken>();
            ResetPasswordTokens = new HashSet<ResetPasswordToken>();
        }

        public int Iduser { get; set; }
        public string? Address { get; set; }
        public string? Avatar { get; set; }
        public string? Email { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Password { get; set; }
        public string? PhoneNumber { get; set; }
        public byte[]? Role { get; set; }
        public int? Status { get; set; }
        public string? UserName { get; set; }

        public virtual ICollection<Cart> Carts { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
        public virtual ICollection<RegistrationUserToken> RegistrationUserTokens { get; set; }
        public virtual ICollection<ResetPasswordToken> ResetPasswordTokens { get; set; }
    }
}
