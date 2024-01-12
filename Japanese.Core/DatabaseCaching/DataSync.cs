using Japanese.Core.RepositoryBase.MongoDB;
using Redis.OM;
using Redis.OM.Searching;

namespace Japanese.Redis;

public class DataSync<TModel> where TModel : class, new()
{
    //private readonly IAppRepository<TModel> _appRepository;
    //private readonly RedisConnectionProvider _provider;
    //private readonly RedisCollection<TModel> _collection;

    //public DataSync(IAppRepository<TModel> appRepository, RedisConnectionProvider provider)
    //{
    //    _appRepository = appRepository;
    //    _provider = provider;
    //    _collection = (RedisCollection<TModel>)provider.RedisCollection<TModel>();
    //}

    public async Task CreateIndexAsync()
    {
        //RedisIndexInfo? redisIndexInfo = await _provider.Connection.GetIndexInfoAsync(typeof(TModel));
        //if (redisIndexInfo is null)
        //    await _provider.Connection.CreateIndexAsync(typeof(TModel));
    }

    public async Task BulkInsertAsync()
    {
        //if(await _collection.CountAsync() > 0) 
        //    return;

        //List<TModel> models = await _appRepository.Helper.ScanAllAsync<TModel>(useRemaining: true);
        //await _collection.InsertAsync(models);

        //models.Clear();
        //models = null!;
        //GC.Collect();
    }
}