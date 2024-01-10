using Microsoft.Extensions.Hosting;

namespace Japanese.Core.BackgroundTasks;

public class CacheRefreshService : BackgroundService, IDisposable
{
    private bool disposedValue;

    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        throw new NotImplementedException();
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
