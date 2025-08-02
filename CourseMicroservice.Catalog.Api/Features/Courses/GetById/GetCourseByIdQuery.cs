using CourseMicroservice.Catalog.Api.Features.Courses.Dtos;

namespace CourseMicroservice.Catalog.Api.Features.Courses.GetById
{
    public record GetCourseByIdQuery(Guid Id) : IRequestByServiceResult<CourseDto>;
}
