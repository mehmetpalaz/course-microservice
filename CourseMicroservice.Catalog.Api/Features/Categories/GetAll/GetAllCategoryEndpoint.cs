using CourseMicroservice.Catalog.Api.Features.Categories.Dtos;
using CourseMicroservice.Catalog.Api.Repositories;

namespace CourseMicroservice.Catalog.Api.Features.Categories.GetAll
{
    public record GetAllCategoryQuery : IRequestByServiceResult<List<CategoryDto>>;

    public class GetAllCategoryQueryHandler(AppDbContext context, IMapper mapper) : IRequestHandler<GetAllCategoryQuery, ServiceResult<List<CategoryDto>>>
    {
        public async Task<ServiceResult<List<CategoryDto>>> Handle(GetAllCategoryQuery request, CancellationToken cancellationToken)
        {
            var categories = await context.Categories
                .ToListAsync(cancellationToken);

            var mappedCategories = mapper.Map<List<CategoryDto>>(categories);

            return ServiceResult<List<CategoryDto>>.SuccessAsOk(mappedCategories);
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
