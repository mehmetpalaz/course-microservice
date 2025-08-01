using CourseMicroservice.Catalog.Api.Features.Categories.Create;
using CourseMicroservice.Catalog.Api.Features.Categories.GetAll;

namespace CourseMicroservice.Catalog.Api.Features.Categories
{
    public static class CategoryEndpointExt
    {
        public static WebApplication AddCategoryEnpointExt(this WebApplication app)
        {
            app.MapGroup("/api/categories").CreateCategoryGroupItem()
                .GetAllCategoryGroupItem();

            return app;
        }
    }
}
