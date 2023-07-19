using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Japanese.Repositories.Interfaces;
using Japanese.Repositories.Implements;

namespace Japanese.Repositories;

public static class RepositoryRegistration
{
    public static IServiceCollection AddRepositories(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IJapaneseRepository, JapaneseRepository>();

        return services;
    }
}
