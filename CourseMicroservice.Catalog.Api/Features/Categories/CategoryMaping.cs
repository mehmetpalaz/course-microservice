using CourseMicroservice.Catalog.Api.Features.Categories.Dtos;

namespace CourseMicroservice.Catalog.Api.Features.Categories
{
    public class CategoryMaping : Profile
    {
        public CategoryMaping()
        {
            CreateMap<Category, CategoryDto>().ReverseMap();
        }
    }
}
