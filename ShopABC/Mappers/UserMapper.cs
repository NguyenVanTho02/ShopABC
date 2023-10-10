using AutoMapper;
using ShopABC.Entities;
using ShopABC.Models;

namespace ShopABC.Mappers
{
    public class UserMapper : Profile
    {
        public UserMapper() {
            CreateMap<User, SignIn>().ReverseMap();
            CreateMap<User, SignUp>().ReverseMap();
            CreateMap<User, UserModel>().ReverseMap();
        } 
    }
}
