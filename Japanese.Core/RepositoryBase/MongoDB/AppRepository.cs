using Japanese.Core.CommonModels;
using Japanese.Core.MongoDB;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System.Linq.Expressions;

namespace Japanese.Core.RepositoryBase.MongoDB;

public class AppRepository<TModel> : IAppRepository<TModel> where TModel : MongoDBModel
{
    private readonly IMongoDatabase _database;
    private readonly IMongoCollection<TModel> _collection;
    private readonly string _collectionName;

    protected MongoDBHelper<TModel> MongoDBHelper { get => new MongoDBHelper<TModel>(_database, _collectionName); }

    public IMongoCollection<TModel> Collection => _collection;

    public AppRepository(IMongoDatabase database, string collectionName)
    {
        _database = database;
        _collectionName = collectionName;
        _collection = _database.GetCollection<TModel>(collectionName);
    }

    public async Task<PagedResult<TModel>> GetPaginatedAsync(Pagination pagination) 
        => await MongoDBHelper.GetPaginatedAsync(pagination);

    public async Task<TModel> GetAsync(ObjectId id)
        => await _collection.AsQueryable().Where(x => x.Id == id).SingleOrDefaultAsync();

    public async Task InsertAsync(params TModel[] models) => await MongoDBHelper.InsertAsync(models);

    public async Task UpdateAsync(TModel model, Expression<Func<TModel, object>> filterEq, object filterEqVal, Dictionary<string, object> updates)
        => await MongoDBHelper.UpdateAsync(model, filterEq, filterEqVal, updates);
}