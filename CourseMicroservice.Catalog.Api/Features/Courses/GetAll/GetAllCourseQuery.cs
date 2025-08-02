using CourseMicroservice.Catalog.Api.Features.Courses.Dtos;

namespace CourseMicroservice.Catalog.Api.Features.Courses.GetAll
{
    public record GetAllCourseQuery : IRequestByServiceResult<List<CourseDto>>;
}
