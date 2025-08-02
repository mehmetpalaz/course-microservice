
using CourseMicroservice.Catalog.Api.Repositories;

namespace CourseMicroservice.Catalog.Api.Features.Courses.Update
{
    public class UpdateCourseCommandHandler(AppDbContext context) : IRequestHandler<UpdateCourseCommand, ServiceResult>
    {
        public async Task<ServiceResult> Handle(UpdateCourseCommand request, CancellationToken cancellationToken)
        {
            var course = await context.Courses
                .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (course is null)
            {
                return ServiceResult.ErrorAsNotFound();
            }

            var hasCategory = await context.Categories.AnyAsync(x => x.Id == request.CategoryId, cancellationToken);

            if (hasCategory is false)
            {
                return ServiceResult.ErrorAsNotFound();
            }

            course.Name = request.Name;
            course.Description = request.Description;
            course.Price = request.Price;
            course.ImageUrl = request.ImageUrl;
            course.CategoryId = request.CategoryId;

            context.Courses.Update(course);

            await context.SaveChangesAsync(cancellationToken);

            return ServiceResult.SuccessAsNoContent();
        }
    }
}
