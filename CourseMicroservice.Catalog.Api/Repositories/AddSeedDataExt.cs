using CourseMicroservice.Catalog.Api.Features.Categories;
using CourseMicroservice.Catalog.Api.Features.Courses;

namespace CourseMicroservice.Catalog.Api.Repositories
{
    public static class AddSeedDataExt
    {
        public static async Task AddSeedData(this WebApplication app)
        {
            using var scope = app.Services.CreateScope();

            var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

            context.Database.AutoTransactionBehavior = AutoTransactionBehavior.Never;

            if (!context.Categories.Any())
            {
                context.Categories.AddRange(
                    new Category { Id = NewId.NextSequentialGuid(), Name = "Programming" },
                    new Category { Id = NewId.NextSequentialGuid(), Name = "Design" },
                    new Category { Id = NewId.NextSequentialGuid(), Name = "Marketing" }
                );
                await context.SaveChangesAsync();
            }
            if (!context.Courses.Any())
            {
                var categoryId = context.Categories.First().Id;
                var userId = NewId.NextSequentialGuid();

                context.Courses.AddRange(
                    new Course
                    {
                        Id = NewId.NextSequentialGuid(),
                        Name = "Introduction to C#",
                        Description = "Learn the basics of C# programming language.",
                        CategoryId = categoryId,
                        CreatedDate = DateTime.UtcNow,
                        Price = 49.99m,
                        ImageUrl = "https://example.com/images/csharp.jpg",
                        UserId = userId,
                        Feature = new Feature
                        {
                            Duration = 30,
                            EducatorFullName = "Mehmet Palaz",
                            Rating = 4
                        }
                    },
                    new Course
                    {
                        Id = NewId.NextSequentialGuid(),
                        Name = "Advanced C# Techniques",
                        Description = "Deep dive into advanced C# programming concepts.",
                        CategoryId = categoryId,
                        CreatedDate = DateTime.UtcNow,
                        Price = 49.99m,
                        ImageUrl = "https://example.com/images/csharp.jpg",
                        UserId = userId,
                        Feature = new Feature
                        {
                            Duration = 30,
                            EducatorFullName = "Mehmet Palaz",
                            Rating = 4
                        }
                    }
                );

                await context.SaveChangesAsync();
            }
        }
    }
}
