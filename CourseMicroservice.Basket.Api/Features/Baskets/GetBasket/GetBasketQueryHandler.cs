using AutoMapper;
using CourseMicroservice.Basket.Api.Consts;
using CourseMicroservice.Basket.Api.Dtos;
using CourseMicroservice.Shared;
using CourseMicroservice.Shared.Services;
using MediatR;
using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;

namespace CourseMicroservice.Basket.Api.Features.Baskets.GetBasket
{
    public class GetBasketQueryHandler(IIdentityService identityService, IDistributedCache distributedCache, IMapper mapper) : IRequestHandler<GetBasketQuery, ServiceResult<BasketDto>>
    {
        public async Task<ServiceResult<BasketDto>> Handle(GetBasketQuery request, CancellationToken cancellationToken)
        {
            var userId = identityService.GetUserId;

            var basketString = await distributedCache.GetStringAsync(string.Format(BasketConsts.BasketRedisKey, userId), cancellationToken);

            if (string.IsNullOrWhiteSpace(basketString))
            {
                return ServiceResult<BasketDto>.SuccessAsOk(new BasketDto(new List<BasketItemDto>()));
            }

            var basket = JsonSerializer.Deserialize<Data.Basket>(basketString);

            var basketDto = mapper.Map<BasketDto>(basket);  

            return ServiceResult<BasketDto>.SuccessAsOk(basketDto!);
        }
    }
}
