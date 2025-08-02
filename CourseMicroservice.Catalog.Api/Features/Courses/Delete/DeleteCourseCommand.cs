namespace CourseMicroservice.Catalog.Api.Features.Courses.Delete
{
    public record DeleteCourseCommand(Guid Id) : IRequestByServiceResult;
}
