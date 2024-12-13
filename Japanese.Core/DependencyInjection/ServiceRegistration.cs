using FluentValidation;
using Japanese.CQRS.Behaviours;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis;
using System.Reflection;
using Redis.OM;
using Japanese.Core.BackgroundServices;
using Japanese.Core.Queue;
using Japanese.Core.CQRS.ExtendedProcessing;

namespace Japanese.Core.DependencyInjection;

public static class ServiceRegistration
{
    public static IServiceCollection AddRedisServices(this IServiceCollection services, IConfiguration configuration)
    {
        string redisConnection = configuration.GetConnectionString("RedisConnection")!;
        IConnectionMultiplexer connectionMultiplexer = ConnectionMultiplexer.Connect(redisConnection);

        services.AddSingleton(new RedisConnectionProvider(connectionMultiplexer));
        services.AddStackExchangeRedisCache(options =>
        {
            options.Configuration = redisConnection;
        });

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
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ExtendedProcessingBehaviour<,>));

        services.AddSingleton<ExtProcCollection>();
        services.AddScoped<ExtProcManager>();

        return services;
    }

    public static IServiceCollection AddQueue<TQueueTask>(this IServiceCollection services)
        where TQueueTask : IQueueTask
    {
        services.AddSingleton<QueueService<TQueueTask>>();
        services.AddHostedService<QueueBackgroundService<TQueueTask>>();

        return services;
    }
}