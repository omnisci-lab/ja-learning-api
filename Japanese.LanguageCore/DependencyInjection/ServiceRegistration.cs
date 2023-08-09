using Japanese.LanguageCore.AWS;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Japanese.LanguageCore.DependencyInjection;

public static class ServiceRegistration
{
    public static IServiceCollection AddAwsServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton(s => configuration.GetSection("AWS").Get<AmazonConfiguration>());
        services.AddScoped<IAwsService, AwsService>();

        return services;
    }
}