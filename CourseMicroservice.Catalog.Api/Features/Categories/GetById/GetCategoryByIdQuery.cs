using CourseMicroservice.Catalog.Api.Features.Categories.Dtos;
using CourseMicroservice.Shared;
using MediatR;

namespace CourseMicroservice.Catalog.Api.Features.Categories.GetById
{
    public record GetCategoryByIdQuery(Guid Id) : IRequest<ServiceResult<List<CategoryDto>>>;
}
