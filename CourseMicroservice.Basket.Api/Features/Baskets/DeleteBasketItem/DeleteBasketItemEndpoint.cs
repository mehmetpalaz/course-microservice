using CourseMicroservice.Basket.Api.Features.Baskets.AddBasketItem;
using CourseMicroservice.Shared.Extensions;
using CourseMicroservice.Shared.Filters;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CourseMicroservice.Basket.Api.Features.Baskets.DeleteBasketItem
{
    public static class DeleteBasketItemEndpoint
    {
        public static RouteGroupBuilder AddDeleteBasketItemEndpoint(this RouteGroupBuilder app)
        {
            app.MapDelete("/item", async ([FromBody] DeleteBasketItemCommand command, IMediator mediator) =>
            {
                var result = await mediator.Send(command);

                return result.ToEndpointResult();
            }).WithName("DeleteBasketItem")
              .MapToApiVersion(1, 0)
              .AddEndpointFilter<ValidationFilter<DeleteBasketItemCommandValidator>>();

            return app;
        }

    }
}
