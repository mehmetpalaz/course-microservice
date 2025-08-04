using CourseMicroservice.Catalog.Api.Features.Courses.Dtos;

namespace CourseMicroservice.Catalog.Api.Features.Courses.GetAllByUserId
{
    public record GetAllCourseByUserIdQuery(Guid UserId) : IRequestByServiceResult<List<CourseDto>>;
}
