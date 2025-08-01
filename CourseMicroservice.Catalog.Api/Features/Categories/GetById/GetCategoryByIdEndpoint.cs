namespace CourseMicroservice.Catalog.Api.Features.Categories.GetById
{
    public static class GetCategoryByIdEndpoint
    {
        public static RouteGroupBuilder GetCategoryByIdGroupItem(this RouteGroupBuilder routeGroup)
        {
            routeGroup.MapGet("/{id:guid}", async (Guid id, IMediator mediator) =>
            {
                var result = await mediator.Send(new GetCategoryByIdQuery(id));

                return result.ToEndpointResult();
            });

            return routeGroup;
        }
    }
}
