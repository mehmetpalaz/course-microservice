namespace CourseMicroservice.Catalog.Api.Features.Courses.Delete
{
    public static class DeleteCourseCommandEndpoint
    {
        public static RouteGroupBuilder DeleteCourseGroupItem(this RouteGroupBuilder app)
        {
            app.MapDelete("/{id}", async (Guid id, IMediator mediator) =>
            {
                var result = await mediator.Send(new DeleteCourseCommand(id));

                return result.ToEndpointResult();
            }).WithName("DeleteCourse");

            return app;
        }
    }
}
