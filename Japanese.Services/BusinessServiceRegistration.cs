using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Microsoft.Extensions.Configuration;
using Japanese.Core.DependencyInjection;

namespace Japanese.Services;

public static class BusinessServiceRegistration
{
    public static IServiceCollection AddBusinessServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddRedisServices(configuration);

        services.AddElasticServices(configuration, Assembly.GetExecutingAssembly());
        services.AddCqrs(Assembly.GetExecutingAssembly());
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        IConfigurationSection jwtSection = configuration.GetSection("JWT");
        string? validAudience = jwtSection.GetSection("ValidAudience").Value;
        string? validIssuer = jwtSection.GetSection("ValidIssuer").Value;
        string? secret = jwtSection.GetSection("Secret").Value;
        services.AddScoped<ConfigurationJWT>(s => new ConfigurationJWT { Secret = secret, ValidAudience = validAudience, ValidIssuer = validIssuer });
        services.AddScoped<Token>();
        return services;
    }
}