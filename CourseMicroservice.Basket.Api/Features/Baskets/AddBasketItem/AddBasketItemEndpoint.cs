using CourseMicroservice.Shared;
using CourseMicroservice.Shared.Extensions;
using CourseMicroservice.Shared.Filters;
using MediatR;

namespace CourseMicroservice.Basket.Api.Features.Baskets.AddBasketItem
{
    public static class AddBasketItemEndpoint
    {
        public static RouteGroupBuilder AddBasketItemGroupItemEndpoint(this RouteGroupBuilder app)
        {
            app.MapPost("/item", async (AddBasketItemCommand command, IMediator mediator) =>
            {
                var result = await mediator.Send(command);

                return result.ToEndpointResult();
            })
            .WithName("AddBasketItem")
            .MapToApiVersion(1, 0)
            .AddEndpointFilter<ValidationFilter<AddBasketItemCommandValidator>>();

            return app;
        }
    }
}
