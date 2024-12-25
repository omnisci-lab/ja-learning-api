using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Japanese.Repositories.Interfaces;
using Japanese.Repositories.Implements;
using Japanese.Core.MongoDB;
using Japanese.Core.DependencyInjection;

namespace Japanese.Repositories;

public static class RepositoryRegistration
{
    public static IServiceCollection AddRepositories(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton(configuration.GetSection("MongoDB").Get<MongoDBConfiguration>()!);
        services.AddScoped<IJapaneseRepository, JapaneseRepository>();

        services.AddDataCleaner<IJapaneseRepository>();

        return services;
    }
}