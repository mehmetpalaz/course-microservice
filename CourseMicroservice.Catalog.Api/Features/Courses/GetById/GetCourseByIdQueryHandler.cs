using CourseMicroservice.Catalog.Api.Features.Categories.Dtos;
using CourseMicroservice.Catalog.Api.Features.Courses.Dtos;
using CourseMicroservice.Catalog.Api.Repositories;

namespace CourseMicroservice.Catalog.Api.Features.Courses.GetById
{
    public class GetCourseByIdQueryHandler(AppDbContext context, IMapper mapper) : IRequestHandler<GetCourseByIdQuery, ServiceResult<CourseDto>>
    {
        public async Task<ServiceResult<CourseDto>> Handle(GetCourseByIdQuery request, CancellationToken cancellationToken)
        {
            var course = await context.Courses
                .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (course is null)
            {
                return ServiceResult<CourseDto>.Error("The course was not found.", HttpStatusCode.NotFound);
            }

            course.Category = await context.Categories
               .Where(x => x.Id == course.CategoryId)
               .FirstAsync(cancellationToken);

            var courseDto = mapper.Map<CourseDto>(course);


            return ServiceResult<CourseDto>.SuccessAsOk(courseDto);
        }
    }
}
