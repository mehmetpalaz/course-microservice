using AutoMapper;

namespace CourseMicroservice.Basket.Api.Features.Baskets
{
    public class BasketMapping : Profile
    {
        public BasketMapping()
        {
            CreateMap<Data.BasketItem, Dtos.BasketItemDto>().ReverseMap();
            CreateMap<Data.Basket, Dtos.BasketDto>().ReverseMap();
        }
    }
}
