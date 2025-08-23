using CourseMicroservice.Shared.Extensions;
using MediatR;

namespace CourseMicroservice.Basket.Api.Features.Baskets.GetBasket
{
    public static class GetBasketEndpoint
    {
        public static RouteGroupBuilder BasketEndpoint(this RouteGroupBuilder app)
        {
            app.MapGet("/user", async (IMediator mediator) =>
            {
                var result = await mediator.Send(new GetBasketQuery());

                return result.ToEndpointResult();

            }).WithName("GetBasket")
              .MapToApiVersion(1, 0);

            return app;
        }
    }
}
