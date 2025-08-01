using CourseMicroservice.Catalog.Api.Features.Categories.Dtos;

namespace CourseMicroservice.Catalog.Api.Features.Categories.GetById
{
    public record GetCategoryByIdQuery(Guid Id) : IRequestByServiceResult<List<CategoryDto>>;
}
