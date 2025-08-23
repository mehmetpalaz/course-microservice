using CourseMicroservice.Basket.Api.Dtos;
using CourseMicroservice.Shared;

namespace CourseMicroservice.Basket.Api.Features.Baskets.GetBasket
{
    public record GetBasketQuery : IRequestByServiceResult<BasketDto>;
}
