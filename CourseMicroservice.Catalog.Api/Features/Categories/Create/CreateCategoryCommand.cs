using CourseMicroservice.Shared;
using MediatR;

namespace CourseMicroservice.Catalog.Api.Features.Categories.Create
{
    public record CreateCategoryCommand(string Name) : IRequestByServiceResult<CreateCategoryResponse>;
}
