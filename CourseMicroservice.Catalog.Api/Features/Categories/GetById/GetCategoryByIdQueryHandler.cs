using CourseMicroservice.Catalog.Api.Features.Categories.Dtos;
using CourseMicroservice.Catalog.Api.Repositories;

namespace CourseMicroservice.Catalog.Api.Features.Categories.GetById
{
    public class GetCategoryByIdQueryHandler(AppDbContext context, IMapper mapper) : IRequestHandler<GetCategoryByIdQuery, ServiceResult<List<CategoryDto>>>
    {
        public async Task<ServiceResult<List<CategoryDto>>> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            var cateogy = await context.Categories.FindAsync(request.Id);

            if (cateogy is null)
            {
                return ServiceResult<List<CategoryDto>>.Error("Category not found.", $"The category with Id({request.Id}) was not found.",
                    System.Net.HttpStatusCode.NotFound);
            }

            var categoryDto = mapper.Map<CategoryDto>(cateogy);

            return ServiceResult<List<CategoryDto>>.SuccessAsOk(new List<CategoryDto> { categoryDto });
        }
    }
}
