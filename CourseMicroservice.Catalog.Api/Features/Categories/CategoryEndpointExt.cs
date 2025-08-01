﻿using CourseMicroservice.Catalog.Api.Features.Categories.Create;
using CourseMicroservice.Catalog.Api.Features.Categories.GetAll;
using CourseMicroservice.Catalog.Api.Features.Categories.GetById;

namespace CourseMicroservice.Catalog.Api.Features.Categories
{
    public static class CategoryEndpointExt
    {
        public static WebApplication AddCategoryEnpointExt(this WebApplication app)
        {
            app.MapGroup("/api/categories")
                .WithTags("Categories")
                .CreateCategoryGroupItem()
                .GetAllCategoryGroupItem()
                .GetCategoryByIdGroupItem();

            return app;
        }
    }
}
