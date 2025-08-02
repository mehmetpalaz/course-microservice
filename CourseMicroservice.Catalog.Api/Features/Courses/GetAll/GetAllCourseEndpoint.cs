namespace CourseMicroservice.Catalog.Api.Features.Courses.GetAll
{
    public static class GetAllCourseEndpoint
    {
        public static RouteGroupBuilder GetAllCourseGroupItem(this RouteGroupBuilder app)
        {
            app.MapGet("/", async (IMediator mediator) =>
            {
                var result = await mediator.Send(new GetAllCourseQuery());
                
                return result.ToEndpointResult();

            }).WithName("GetAllCourse");
           
            return app;
        }
    }
}
