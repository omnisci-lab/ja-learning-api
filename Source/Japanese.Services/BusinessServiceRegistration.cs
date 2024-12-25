using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Microsoft.Extensions.Configuration;
using Japanese.Core.DependencyInjection;
using Japanese.Services.Kanji.Queues;

namespace Japanese.Services;

public static class BusinessServiceRegistration
{
    public static IServiceCollection AddBusinessServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddRedisServices(configuration);
        services.AddCqrs(Assembly.GetExecutingAssembly());
        services.AddAutoMapper(Assembly.GetExecutingAssembly());

        services.AddQueue<KanjiQueueTask>();

        return services;
    }
}