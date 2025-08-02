namespace CourseMicroservice.Catalog.Api.Features.Courses.GetById
{
    public static class GetCourseByIdEndpoint
    {
        public static RouteGroupBuilder GetCourseByIdGroupItem(this RouteGroupBuilder app)
        {
            app.MapGet("/{id:guid}", async (Guid id, IMediator mediator) =>
            {
                var query = new GetCourseByIdQuery(id);

                return await mediator.Send(query);
            })
                .WithName("GetCourseById");

            return app;
        }
    }
}
