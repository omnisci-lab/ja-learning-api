using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Japanese.CachedRepository.Implements;
using Japanese.CachedRepository.Interfaces;

namespace Japanese.Repositories;

public static class CachedRepositoryRegistration
{
    public static IServiceCollection AddCachedRepositories(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IJapaneseCachedRepository, JapaneseCachedRepository>();

        return services;
    }
}