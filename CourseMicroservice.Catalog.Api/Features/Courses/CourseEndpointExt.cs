using CourseMicroservice.Catalog.Api.Features.Courses.Create;
using CourseMicroservice.Catalog.Api.Features.Courses.Delete;
using CourseMicroservice.Catalog.Api.Features.Courses.GetAll;
using CourseMicroservice.Catalog.Api.Features.Courses.GetById;
using CourseMicroservice.Catalog.Api.Features.Courses.Update;

namespace CourseMicroservice.Catalog.Api.Features.Courses
{
    public static class CourseEndpointExt
    {
        public static WebApplication AddCourseEndpointsExt(this WebApplication app)
        {
            app.MapGroup("/api/courses")
                .WithTags("Courses")
                .AddCreateCourseGroupItem()
                .GetAllCourseGroupItem()
                .GetCourseByIdGroupItem()
                .UpdateCourseCommandGroupItem()
                .DeleteCourseGroupItem();

            return app;
        }
    }
}
