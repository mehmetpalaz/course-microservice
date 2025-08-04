using CourseMicroservice.Shared.Filters;

namespace CourseMicroservice.Catalog.Api.Features.Courses.Update
{
    public static class UpdateCourseCommandEndpoint
    {
        public static RouteGroupBuilder UpdateCourseCommandGroupItem(this RouteGroupBuilder app)
        {
            app.MapPut("/", async (UpdateCourseCommand command, IMediator mediator) =>
            {
                return await mediator.Send(command);
            })
            .WithName("UpdateCourse").MapToApiVersion(1, 0)
            .AddEndpointFilter<ValidationFilter<UpdateCourseCommand>>();

            return app;
        }
    }
}
