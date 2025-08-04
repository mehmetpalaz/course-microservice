namespace CourseMicroservice.Catalog.Api.Features.Courses.GetAllByUserId
{
    public static class GetAllCourseByUserIdEndpoint
    {
        public static RouteGroupBuilder GetAllCourseByUserIdGroupItem(this RouteGroupBuilder app)
        {
            app.MapGet("/user/{id}", async (Guid id, IMediator mediator) =>
            {
                var result = await mediator.Send(new GetAllCourseByUserIdQuery(id));
                
                return result.ToEndpointResult();

            }).WithName("GetAllCourseByUserId").MapToApiVersion(1, 0);
           
            return app;
        }
    }
}
