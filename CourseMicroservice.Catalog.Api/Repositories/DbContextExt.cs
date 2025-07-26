using CourseMicroservice.Catalog.Api.Options;
using MongoDB.Driver;

namespace CourseMicroservice.Catalog.Api.Repositories
{
    public static class DbContextExt
    {
        public static IServiceCollection AddDbContextExt(this IServiceCollection services)
        {
            services.AddSingleton<IMongoClient, MongoClient>(MongoClient =>
            {
                var mongoOption = MongoClient.GetRequiredService<MongoOption>();
                return new MongoClient(mongoOption.ConnectionString);
            });

            services.AddScoped<AppDbContext>(sp =>
            {
                var mongoOption = sp.GetRequiredService<MongoOption>();
                var client = sp.GetRequiredService<IMongoClient>();

                var database = client.GetDatabase(mongoOption.DatabaseName);

                return AppDbContext.Create(database);
            });

            return services;
        }
    }
}
