using AutoMapper;
using ShopABC.Entities;
using ShopABC.Models;

namespace ShopABC.Mappers
{
    public class BrandMapper : Profile
    {
        public BrandMapper()
        {
            CreateMap<Brand, BrandModel>().ReverseMap();
        }
    }
}
