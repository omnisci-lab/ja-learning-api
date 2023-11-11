using FluentValidation;
using Japanese.Core.Plugin;
using Japanese.CQRS.Behaviours;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Nest;
using System.Reflection;

namespace Japanese.Core.DependencyInjection;

public static class ServiceRegistration
{
    public static IServiceCollection AddRedisServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddStackExchangeRedisCache(options =>
        {
            options.Configuration = configuration.GetConnectionString("RedisConnection");
        });

        services.AddSingleton<PluginCollection>();
        services.AddScoped<PluginManager>();

        return services;
    }

    public static IServiceCollection AddElasticServices(this IServiceCollection services, IConfiguration configuration, Assembly assembly)
    {
        IConfigurationSection elasticSection = configuration.GetSection("Elasticsearch");
        string? uri = elasticSection.GetSection("Uri").Value;
        string? defaultIndex = elasticSection.GetSection("DefaultIndex").Value;
        string? userName = elasticSection.GetSection("UserName").Value;
        string? password = elasticSection.GetSection("Url").Value;

        ConnectionSettings settings = new ConnectionSettings(new Uri(uri!))
        .PrettyJson()
        .DefaultIndex(defaultIndex);

        IElasticClient elasticClient = new ElasticClient(settings);

        Type[] types = assembly.GetExportedTypes()
            .Where(x => x.GetInterfaces().Any(i => i == typeof(IElasticsearchIndex)))
            .ToArray();

        foreach(Type type in types){
            (Activator.CreateInstance(type) as IElasticsearchIndex)!.CreateIndexes(elasticClient);
        }

        services.AddSingleton(elasticClient);

        return services;
    }

    public static IServiceCollection AddCqrs(this IServiceCollection services, Assembly assembly)
    {
        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(assembly);
        });

        services.AddValidatorsFromAssembly(assembly);

        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(UnhandledExceptionBehaviour<,>));
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(CachingBehavior<,>));
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(PluginExecutionBehaviour<,>));

        return services;
    }
}