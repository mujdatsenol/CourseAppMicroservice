using CourseAppMicroservice.Catalog.Api.Options;
using MongoDB.Driver;

namespace CourseAppMicroservice.Catalog.Api.Repositories;

public static class RepositoryExtension
{
    public static IServiceCollection AddDatabaseService(this IServiceCollection services)
    {
        services.AddSingleton<IMongoClient, MongoClient>(sp =>
        {
            var options = sp.GetRequiredService<MongoOption>();
            return new MongoClient(options.ConnectionString);
        });

        services.AddScoped(sp =>
        {
            var mongoClient = sp.GetRequiredService<IMongoClient>();
            var options = sp.GetRequiredService<MongoOption>();

            return AppDbContext.Create(mongoClient.GetDatabase(options.DatabaseName));
        });
        
        return services;
    }
}