using AutoMapper;
using ShopABC.Entities;
using ShopABC.Models;

namespace ShopABC.Mappers
{
    public class CategoryMapper : Profile
    {
        public CategoryMapper()
        {
            CreateMap<Category, CategoryModel>().ReverseMap();
        }
    }
}
