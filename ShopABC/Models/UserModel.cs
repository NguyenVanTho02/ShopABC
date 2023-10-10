using ShopABC.Entities;

namespace ShopABC.Models
{
    public class UserModel
    {
        public int Iduser { get; set; }
        public string? Address { get; set; }
        public string? Avatar { get; set; }
        public string Email { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string? PhoneNumber { get; set; }
        public byte[]? Role { get; set; }
        public int? Status { get; set; }
        public string UserName { get; set; } = null!;
        public UserModel()
        {
            
        }
        public UserModel(User user)
        {
            Iduser = user.Iduser;
            Address = user.Address;
            Avatar = user.Avatar;
            Email = user.Email;
            FirstName = user.FirstName;
            LastName = user.LastName;
            Password = user.Password;
            PhoneNumber = user.PhoneNumber;
            Role = user.Role;
            Status = user.Status;
            UserName = user.UserName;
        }
    }
}
