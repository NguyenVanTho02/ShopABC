using System.ComponentModel.DataAnnotations;

namespace ShopABC.Models
{
    public class SignIn
    {
        [Required]
        public string UserName { get; set; } = null!;
        [Required]
        public string Password { get; set; } = null!;
    }
}
