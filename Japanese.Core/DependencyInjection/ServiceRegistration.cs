using FluentValidation;
using Japanese.Core.Plugin;
using Japanese.CQRS.Behaviours;
using Japanese.Core.AWS;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis;
using System.Reflection;
using Japanese.Core.BackgroundTasks;
using Redis.OM;
using Japanese.Core.RepositoryBase.MongoDB;

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
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(PluginExecutionBehaviour<,>));

        services.AddSingleton<PluginCollection>();
        services.AddScoped<PluginManager>();

        return services;
    }

    public static IServiceCollection AddAwsServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton(s => configuration.GetSection("AWS").Get<AmazonConfiguration>()!);
        services.AddScoped<IAwsService, AwsService>();

        return services;
    }

    //public static IServiceCollection AddDbCacheServices<TMasterRepository, TModel>(this IServiceCollection services, Func<TMasterRepository, IAppRepository<TModel>> selectRepository) 
    //    where TMasterRepository : IMasterRepository 
    //    where TModel : class, new()
    //{
    //    //services.AddHostedService(i => new CacheRefreshService<TMasterRepository, TModel>(i, selectRepository));

    //    return services;
    //}
}