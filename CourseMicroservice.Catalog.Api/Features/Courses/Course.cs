using CourseMicroservice.Catalog.Api.Features.Categories;
using CourseMicroservice.Catalog.Api.Repositories;

namespace CourseMicroservice.Catalog.Api.Features.Courses
{
    public class Course : BaseEntity
    {
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public decimal Price { get; set; }
        public string? Picture { get; set; }

        public Guid UserId { get; set; }
        public Guid CategoryId { get; set; }
        public DateTime CreatedDate { get; set; } = default!;
        public Category Category { get; set; } = default!;

        public Feature Feature { get; set; } = default!;
    }
}
