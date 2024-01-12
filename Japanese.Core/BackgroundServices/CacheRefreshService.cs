using Japanese.Core.MongoDB;
using Japanese.Core.RepositoryBase.MongoDB;
using Japanese.Redis;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Redis.OM;

namespace Japanese.Core.BackgroundTasks;

public class CacheRefreshService<TMasterRepository, TModel> : BackgroundService
    where TMasterRepository : IMasterRepository
    where TModel : MongoDBModel, new()
{
    private readonly IServiceProvider _serviceProvider;
    private Func<TMasterRepository, IAppRepository<TModel>> _selectRepository;

    public CacheRefreshService(IServiceProvider serviceProvider, Func<TMasterRepository, IAppRepository<TModel>> selectRepository)
    {
        _serviceProvider = serviceProvider;
        _selectRepository = selectRepository;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            using (IServiceScope serviceScope = _serviceProvider.CreateScope())
            {
                using TMasterRepository masterRepository = serviceScope.ServiceProvider.GetService<TMasterRepository>()!;
                IAppRepository<TModel> repository = _selectRepository(masterRepository);
                RedisConnectionProvider _redisConnectionProvider = serviceScope.ServiceProvider.GetRequiredService<RedisConnectionProvider>();

                //DataSync<TModel> dataSync = new DataSync<TModel>(repository, _redisConnectionProvider);

                //await dataSync.CreateIndexAsync();
                //await dataSync.BulkInsertAsync();
            }

            await Task.Delay(TimeSpan.FromMinutes(30));
        }
    }
}