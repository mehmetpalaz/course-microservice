using CourseMicroservice.Shared.Extensions;
using MediatR;

namespace CourseMicroservice.Catalog.Api.Features.Categories.Create
{
    public static class CreateCategoryEndpointExt
    {
        public static RouteGroupBuilder CreateCategoryGroupItem(this RouteGroupBuilder routeGroup)
        {
            routeGroup.MapPost("/", async (CreateCategoryCommand command, IMediator mediator) =>
            {
                var result = await mediator.Send(command);

                return result.ToEndpointResult();
            });

            return routeGroup;
        }
    }
}
