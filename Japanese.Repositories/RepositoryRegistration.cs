using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Japanese.Repositories.Interfaces;
using Japanese.Repositories.Implements;
using MongoDB.Driver;
using Japanese.Core.MongoDB;
using Japanese.Core.AWS;
using Japanese.Core.DependencyInjection;

namespace Japanese.Repositories;

public static class RepositoryRegistration
{
    public static IServiceCollection AddRepositories(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddAwsServices(configuration);
        services.AddSingleton(configuration.GetSection("MongoDB").Get<MongoDBConfiguration>()!);
        services.AddScoped<IJapaneseRepository, JapaneseRepository>();

        //services.AddDbCacheServices<IJapaneseRepository, Kanjidic2Model>(m => m.Kanjidic2Repository);
        //services.AddDbCacheServices<IJapaneseRepository, SentenceModel>(m => m.SentenceRepository);

        return services;
    }
}