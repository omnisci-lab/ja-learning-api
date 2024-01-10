using Japanese.Core.RepositoryBase;
using Japanese.Redis;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using StackExchange.Redis;

namespace Japanese.Core.BackgroundTasks;

public class CacheRefreshService<TMasterRepository, TModel> : BackgroundService, IDisposable 
    where TMasterRepository : IMasterRepository
    where TModel : class, new()
{
    private readonly IServiceProvider _serviceProvider;
    private Func<TMasterRepository, IAppRepository<TModel>> _selectRepository;
    private bool disposedValue;

    public CacheRefreshService(IServiceProvider serviceProvider, Func<TMasterRepository, IAppRepository<TModel>> selectRepository)
    {
        _serviceProvider = serviceProvider;
        _selectRepository = selectRepository;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        using IServiceScope scope = _serviceProvider.CreateScope();
        TMasterRepository masterRepository = scope.ServiceProvider.GetService<TMasterRepository>()!;
        IConnectionMultiplexer connectionMultiplexer = scope.ServiceProvider.GetRequiredService<IConnectionMultiplexer>();

        IAppRepository<TModel> repository = _selectRepository(masterRepository);

        DataSync<TModel> dataSync = new DataSync<TModel>(repository, connectionMultiplexer);
        await dataSync.CopyDataAsync("aaa");

        await Task.CompletedTask;
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!disposedValue)
        {
            if (disposing)
            {

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
