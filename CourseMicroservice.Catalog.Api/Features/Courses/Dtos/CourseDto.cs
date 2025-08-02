using CourseMicroservice.Catalog.Api.Features.Categories;
using CourseMicroservice.Catalog.Api.Features.Categories.Dtos;

namespace CourseMicroservice.Catalog.Api.Features.Courses.Dtos
{
    public record CourseDto
    {
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public decimal Price { get; set; }
        public string? ImageUrl { get; set; }
        public Guid CategoryId { get; set; }
        public DateTime CreatedDate { get; set; } = default!;
        public CategoryDto Category { get; set; } = default!;
        public Feature Feature { get; set; } = default!;
    }
}
