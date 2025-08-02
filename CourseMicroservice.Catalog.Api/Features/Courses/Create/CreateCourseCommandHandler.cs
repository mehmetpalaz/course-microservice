
using CourseMicroservice.Catalog.Api.Repositories;

namespace CourseMicroservice.Catalog.Api.Features.Courses.Create
{
    public class CreateCourseCommandHandler(AppDbContext context, IMapper mapper) : IRequestHandler<CreateCourseCommand, ServiceResult<Guid>>
    {
        public async Task<ServiceResult<Guid>> Handle(CreateCourseCommand request, CancellationToken cancellationToken)
        {
            var hasCategory = await context.Categories.AnyAsync(x => x.Id == request.CategoryId, cancellationToken);

            if (hasCategory is false)
            {
                return ServiceResult<Guid>.Error("The category was not found.", HttpStatusCode.NotFound);
            }

            var hasCourse = await context.Courses.AnyAsync(x => x.Name == request.Name, cancellationToken);

            if (hasCourse)
            {
                return ServiceResult<Guid>.Error("A course with this name already exists.", HttpStatusCode.Conflict);
            }

            var newCourse = mapper.Map<Course>(request);

            newCourse.Id = NewId.NextSequentialGuid();

            newCourse.CreatedDate = DateTime.UtcNow;

            newCourse.Feature = new Feature
            {
                Duration = 100,
                EducatorFullName = "John Doe",
                Rating = 4,
            };

            context.Courses.Add(newCourse);

            await context.SaveChangesAsync(cancellationToken);

            return ServiceResult<Guid>.SuccessAsCreated(newCourse.Id, $"/api/course/{newCourse.Id}");
        }
    }
}
