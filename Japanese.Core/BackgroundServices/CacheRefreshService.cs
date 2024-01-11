using Japanese.Core.RepositoryBase.DynamoDB;
using Japanese.Redis;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Redis.OM;

namespace Japanese.Core.BackgroundTasks;

public class CacheRefreshService<TMasterRepository, TModel> : BackgroundService, IDisposable 
    where TMasterRepository : IMasterRepository
    where TModel : class, new()
{
    private readonly IServiceProvider _serviceProvider;
    private readonly IServiceScope _serviceScope;
    private readonly TMasterRepository _masterRepository;
    private Func<TMasterRepository, IAppRepository<TModel>> _selectRepository;
    private RedisConnectionProvider _redisConnectionProvider;
    private bool disposedValue;

    public CacheRefreshService(IServiceProvider serviceProvider, Func<TMasterRepository, IAppRepository<TModel>> selectRepository)
    {
        _serviceProvider = serviceProvider;
        _serviceScope = _serviceProvider.CreateScope();
        _masterRepository = _serviceScope.ServiceProvider.GetService<TMasterRepository>()!;
        _selectRepository = selectRepository;
        _redisConnectionProvider = _serviceScope.ServiceProvider.GetRequiredService<RedisConnectionProvider>();
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        IAppRepository<TModel> repository = _selectRepository(_masterRepository);
        DataSync<TModel> dataSync = new DataSync<TModel>(repository, _redisConnectionProvider);

        await dataSync.BulkInsertAsync();
        await Task.CompletedTask;
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!disposedValue)
        {
            if (disposing)
            {
                _masterRepository.Dispose();
                _serviceScope.Dispose();
            }

            disposedValue = true;
        }
    }

    public void Dispose()
    {
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }
}
