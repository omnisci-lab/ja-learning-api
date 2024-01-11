using Japanese.Core.RepositoryBase.DynamoDB;
using Redis.OM;
using Redis.OM.Searching;

namespace Japanese.Redis;

public class DataSync<TModel> where TModel : class, new()
{
    private readonly IAppRepository<TModel> _appRepository;
    private readonly RedisConnectionProvider _provider;
    private readonly RedisCollection<TModel> _collection;

    public DataSync(IAppRepository<TModel> appRepository, RedisConnectionProvider provider) 
    {
        _appRepository = appRepository;
        _provider = provider;
        _collection = (RedisCollection<TModel>)provider.RedisCollection<TModel>();
    }

    public async Task BulkInsertAsync()
    {
        await _provider.Connection.CreateIndexAsync(typeof(TModel));
        List<TModel> models = await _appRepository.Helper.ScanAllAsync<TModel>(useRemaining: false);
        
        if(await _collection.CountAsync() == 0)
            models.ForEach(async (m) => await _collection.InsertAsync(m));
    }
}
