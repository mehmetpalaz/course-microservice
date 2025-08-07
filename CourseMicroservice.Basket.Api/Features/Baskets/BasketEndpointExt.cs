using Asp.Versioning.Builder;
using CourseMicroservice.Basket.Api.Features.Baskets.AddBasketItem;
using MediatR;

namespace CourseMicroservice.Basket.Api.Features.Baskets
{
    public static class BasketEndpointExt
    {
        public static WebApplication AddBasketEndpointsExt(this WebApplication app, ApiVersionSet apiVersionSet)
        {
            app.MapGroup("/api/v{version:apiVersion}/baskets")
                .WithApiVersionSet(apiVersionSet)
                .WithTags("Baskets")
                .AddBasketItemGroupItemEndpoint();

            return app;
        }
    }
}
