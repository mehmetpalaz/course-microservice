using CourseMicroservice.Shared.Filters;

namespace CourseMicroservice.Catalog.Api.Features.Courses.Create
{
    public static class CreateCourseEndpoint
    {
        public static RouteGroupBuilder AddCreateCourseGroupItem(this RouteGroupBuilder group)
        {
            group.MapPost("/", async (CreateCourseCommand command, IMediator mediator) =>
            {
                var result = await mediator.Send(command);
                return result.ToEndpointResult();
            }).WithName("CreateCourse")
            .AddEndpointFilter<ValidationFilter<CreateCourseCommand>>()
            .Produces<ServiceResult<Guid>>(StatusCodes.Status201Created)
            .Produces<ServiceResult<Guid>>(StatusCodes.Status400BadRequest)
            .Produces<ServiceResult<Guid>>(StatusCodes.Status404NotFound)
            .Produces<ServiceResult<Guid>>(StatusCodes.Status409Conflict);

            return group;
        }
    }
}
