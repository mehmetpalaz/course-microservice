using Amazon.Runtime.Internal;
using CourseMicroservice.Catalog.Api.Features.Categories.Create;
using CourseMicroservice.Catalog.Api.Features.Categories.Dtos;
using CourseMicroservice.Catalog.Api.Repositories;
using CourseMicroservice.Shared;
using CourseMicroservice.Shared.Extensions;
using CourseMicroservice.Shared.Filters;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CourseMicroservice.Catalog.Api.Features.Categories.GetAll
{
    public record GetAllCategoryQuery : IRequest<ServiceResult<List<CategoryDto>>>;

    public class GetAllCategoryQueryHandler(AppDbContext context) : IRequestHandler<GetAllCategoryQuery, ServiceResult<List<CategoryDto>>>
    {
        public async Task<ServiceResult<List<CategoryDto>>> Handle(GetAllCategoryQuery request, CancellationToken cancellationToken)
        {
            var categories = await context.Categories
                .Select(c => new CategoryDto(c.Id, c.Name))
                .ToListAsync(cancellationToken);

            return ServiceResult<List<CategoryDto>>.SuccessAsOk(categories);
        }
    }

    public static class GetAllCategoryEndpointExt
    {
        public static RouteGroupBuilder GetAllCategoryGroupItem(this RouteGroupBuilder routeGroup)
        {
            routeGroup.MapGet("/", async (IMediator mediator) =>
            {
                var result = await mediator.Send(new GetAllCategoryQuery());

                return result.ToEndpointResult();

            });

            return routeGroup;
        }
    }
}
