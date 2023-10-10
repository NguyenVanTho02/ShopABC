using AutoMapper;
using ShopABC.Entities;
using ShopABC.Models;

namespace ShopABC.Mappers
{
    public class PostMappers : Profile
    {
        public PostMappers()
        {
            CreateMap<Post, PostModel>().ReverseMap();
        }
    }
}
