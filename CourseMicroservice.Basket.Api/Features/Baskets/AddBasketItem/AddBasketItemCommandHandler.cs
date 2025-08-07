using CourseMicroservice.Basket.Api.Consts;
using CourseMicroservice.Basket.Api.Dtos;
using CourseMicroservice.Shared;
using MediatR;
using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;

namespace CourseMicroservice.Basket.Api.Features.Baskets.AddBasketItem
{
    public class AddBasketItemCommandHandler(IDistributedCache distributedCache) : IRequestHandler<AddBasketItemCommand, ServiceResult>
    {
        public async Task<ServiceResult> Handle(AddBasketItemCommand request, CancellationToken cancellationToken)
        {
            var userId = Guid.NewGuid();

            var basketKey = string.Format(BasketConsts.BasketRedisKey, userId);

            var basketString = await distributedCache.GetStringAsync(basketKey, cancellationToken);

            BasketDto currentBasket = null;

            var basketItem = new BasketItemDto(request.CourseId, request.CourseName, request.ImageUrl, request.CoursePrice, null);

            if (string.IsNullOrEmpty(basketString))
            {
                currentBasket = new BasketDto(userId, [basketItem]);
            }
            else
            {
                currentBasket = JsonSerializer.Deserialize<BasketDto>(basketString)!;
                
                var existingItem = currentBasket.BasketItems.FirstOrDefault(x => x.CourseId == request.CourseId);

                if (existingItem is not null)
                {
                    currentBasket.BasketItems.Remove(existingItem);
                }

                currentBasket.BasketItems.Add(basketItem);
            }

            var updatedBasketString = JsonSerializer.Serialize(currentBasket);

            await distributedCache.SetStringAsync(basketKey, updatedBasketString, cancellationToken);

            return ServiceResult.SuccessAsNoContent();
        }
    }
}
