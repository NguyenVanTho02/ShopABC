using AutoMapper;
using ShopABC.Entities;
using ShopABC.Models;

namespace ShopABC.Mappers
{
    public class PromotionMapper : Profile
    {
        public PromotionMapper()
        {
            CreateMap<Promotion, PromotionModel>().ReverseMap();
        }
    }
}
