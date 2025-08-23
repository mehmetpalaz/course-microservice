using CourseMicroservice.Basket.Api.Consts;
using CourseMicroservice.Basket.Api.Dtos;
using CourseMicroservice.Shared;
using CourseMicroservice.Shared.Services;
using MediatR;
using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;

namespace CourseMicroservice.Basket.Api.Features.Baskets.DeleteBasketItem
{
    public class DeleteBasketItemCommandHandler(IIdentityService identityService, IDistributedCache distributedCache) : IRequestHandler<DeleteBasketItemCommand, ServiceResult>
    {
        public async Task<ServiceResult> Handle(DeleteBasketItemCommand request, CancellationToken cancellationToken)
        {
            var userId = identityService.GetUserId;

            var basketString = await distributedCache.GetStringAsync(string.Format(BasketConsts.BasketRedisKey, userId), cancellationToken);

            if (string.IsNullOrWhiteSpace(basketString))
            {
                return ServiceResult.ErrorAsNotFound();
            }

            var basket = JsonSerializer.Deserialize<Data.Basket>(basketString);

            var course = basket!.Items.FirstOrDefault(x => x.Id == request.CourseId);

            if (course == null)
            {
                return ServiceResult.ErrorAsNotFound();
            }

            basket.Items.Remove(course);

            if (basket.Items.Any())
            {
                await distributedCache.SetStringAsync(string.Format(BasketConsts.BasketRedisKey, userId), JsonSerializer.Serialize(basket), cancellationToken);
            }
            else
            {
                await distributedCache.RemoveAsync(string.Format(BasketConsts.BasketRedisKey, userId), cancellationToken);
            }

            return ServiceResult.SuccessAsNoContent();
        }
    }
}
