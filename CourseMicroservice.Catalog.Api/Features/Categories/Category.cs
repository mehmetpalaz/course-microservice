using CourseMicroservice.Catalog.Api.Features.Courses;
using CourseMicroservice.Catalog.Api.Repositories;

namespace CourseMicroservice.Catalog.Api.Features.Categories
{
    public class Category : BaseEntity
    {
        public string Name { get; set; } = default!;

        public List<Course> Courses { get; set; } = new List<Course>();
    }
}
