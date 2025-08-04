using CourseMicroservice.Catalog.Api.Features.Categories.Dtos;
using CourseMicroservice.Catalog.Api.Features.Courses.Dtos;
using CourseMicroservice.Catalog.Api.Repositories;

namespace CourseMicroservice.Catalog.Api.Features.Courses.GetAllByUserId
{
    public class GetAllCourseByUserIdQueryHandler(AppDbContext context, IMapper mapper) : IRequestHandler<GetAllCourseByUserIdQuery, ServiceResult<List<CourseDto>>>
    {
        public async Task<ServiceResult<List<CourseDto>>> Handle(GetAllCourseByUserIdQuery request, CancellationToken cancellationToken)
        {
            var courses = await context.Courses.Where(x=>x.UserId == request.UserId).ToListAsync(cancellationToken);
           
            var courseDtos = mapper.Map<List<CourseDto>>(courses);

            var categories = await context.Categories.ToListAsync(cancellationToken);

            foreach (var courseDto in courseDtos)
            {
                var category = categories.FirstOrDefault(x => x.Id == courseDto.CategoryId);
                if (category != null)
                {
                    courseDto.Category = mapper.Map<CategoryDto>(category);
                }
            }

            return ServiceResult<List<CourseDto>>.SuccessAsOk(courseDtos);
        }
    }
}
