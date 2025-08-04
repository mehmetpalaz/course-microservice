using Asp.Versioning.Builder;
using CourseMicroservice.Catalog.Api.Features.Categories.Create;
using CourseMicroservice.Catalog.Api.Features.Categories.GetAll;
using CourseMicroservice.Catalog.Api.Features.Categories.GetById;

namespace CourseMicroservice.Catalog.Api.Features.Categories
{
    public static class CategoryEndpointExt
    {
        public static WebApplication AddCategoryEnpointExt(this WebApplication app, ApiVersionSet apiVersionSet)
        {
            app.MapGroup("/api/v{version:apiVersion}/categories")
                .WithApiVersionSet(apiVersionSet)
                .WithTags("Categories")
                .CreateCategoryGroupItem()
                .GetAllCategoryGroupItem()
                .GetCategoryByIdGroupItem();

            return app;
        }
    }
}
