using CourseMicroservice.Catalog.Api.Features.Categories;
using CourseMicroservice.Catalog.Api.Features.Courses;
using MongoDB.Driver;

namespace CourseMicroservice.Catalog.Api.Repositories
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public static AppDbContext Create(IMongoDatabase database) =>
         new(new DbContextOptionsBuilder<AppDbContext>()
          .UseMongoDB(database.Client, database.DatabaseNamespace.DatabaseName)
          .Options);

        public DbSet<Course> Courses { get; set; } = default!;
        public DbSet<Category> Categories { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }
    }
}
