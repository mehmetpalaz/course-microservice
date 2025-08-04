using Asp.Versioning.Builder;
using CourseMicroservice.Catalog.Api.Features.Courses.Create;
using CourseMicroservice.Catalog.Api.Features.Courses.Delete;
using CourseMicroservice.Catalog.Api.Features.Courses.GetAll;
using CourseMicroservice.Catalog.Api.Features.Courses.GetAllByUserId;
using CourseMicroservice.Catalog.Api.Features.Courses.GetById;
using CourseMicroservice.Catalog.Api.Features.Courses.Update;

namespace CourseMicroservice.Catalog.Api.Features.Courses
{
    public static class CourseEndpointExt
    {
        public static WebApplication AddCourseEndpointsExt(this WebApplication app, ApiVersionSet apiVersionSet)
        {
            app.MapGroup("/api/v{version:apiVersion}/courses")
                .WithApiVersionSet(apiVersionSet)
                .WithTags("Courses")
                .AddCreateCourseGroupItem()
                .GetAllCourseGroupItem()
                .GetCourseByIdGroupItem()
                .UpdateCourseCommandGroupItem()
                .DeleteCourseGroupItem()
                .GetAllCourseByUserIdGroupItem();

            return app;
        }
    }
}
