using Japanese.Core.CommonModels;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System.Linq.Expressions;

namespace Japanese.Core.MongoDB;

public class MongoDBHelper<TModel> where TModel : MongoDBModel
{
    private readonly IMongoDatabase _database;
    private readonly IMongoCollection<TModel> _collection;

    public MongoDBHelper(IMongoDatabase database, string collectionName)
    {
        _database = database;
        _collection = _database.GetCollection<TModel>(collectionName);
    }

    public async Task<List<TModel>> GetAllAsync(Expression<Func<TModel, bool>>? predicate = null)
    {
        IMongoQueryable<TModel> queryable = _collection.AsQueryable();
        if(predicate is null)
            return await queryable.ToListAsync();

        return await queryable.Where(predicate).ToListAsync();
    }

    public async Task<PagedResult<TModel>> GetPaginatedAsync(Pagination pagination)
    {
        PagedResult<TModel> pagedResult = new PagedResult<TModel>();
        pagedResult.PageSize = pagination.PageSize;
        pagination.Page = pagination.Page;

        pagedResult.Items = await _collection.AsQueryable()
            .Skip((pagination.Page - 1) * pagination.PageSize).Take(pagination.PageSize).ToListAsync();

        pagedResult.TotalItems = await _collection.AsQueryable()
            .CountAsync();

        return pagedResult;
    }
}
