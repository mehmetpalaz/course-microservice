using CourseMicroservice.Catalog.Api.Repositories;

namespace CourseMicroservice.Catalog.Api.Features.Categories.Create
{
    public class CreateCategoryCommandHandler(AppDbContext context) : IRequestHandler<CreateCategoryCommand, ServiceResult<CreateCategoryResponse>>
    {
        public async Task<ServiceResult<CreateCategoryResponse>> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var isExists = await context.Categories.AnyAsync(c => c.Name == request.Name, cancellationToken);

            if (isExists)
            {
                return ServiceResult<CreateCategoryResponse>.Error("Category already exists.",
                    $"The category name '{request.Name}' is already exist.", HttpStatusCode.BadRequest);
            }

            var catery = new Category
            {
                Id = NewId.NextSequentialGuid(),
                Name = request.Name
            };

            await context.AddAsync(catery, cancellationToken);

            await context.SaveChangesAsync(cancellationToken);

            return ServiceResult<CreateCategoryResponse>.SuccessAsCreated(new CreateCategoryResponse(catery.Id),
                $"/api/categories/{catery.Id}");
        }
    }
}
