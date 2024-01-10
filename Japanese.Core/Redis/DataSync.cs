using Japanese.Core.RepositoryBase;
using StackExchange.Redis;

namespace Japanese.Redis;

public abstract class DataSync<TModel> where TModel : class, new()
{
    private readonly IAppRepository<TModel> _appRepository;
    private RedisHandler<TModel> _redisHandler;

    public DataSync(IAppRepository<TModel> appRepository, IConnectionMultiplexer connectionMultiplexer) 
    {
        _appRepository = appRepository;
        _redisHandler = new RedisHandler<TModel>(connectionMultiplexer);
    }

    public async Task CopyDataAsync(string keyPrefix)
    {
        List<TModel> models = await _appRepository.Helper.ScanAllAsync<TModel>(useRemaining: true);

        foreach(TModel model in models)
        {
            await _redisHandler.Add($"{keyPrefix}:{model.ToString()}", model);
        }
    }
}
