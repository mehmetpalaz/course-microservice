using CourseMicroservice.Shared.Extensions;
using CourseMicroservice.Shared.Filters;

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
            }).WithName("CreateCategory")
                .AddEndpointFilter<ValidationFilter<CreateCategoryCommand>>();

            return routeGroup;
        }
    }
}
