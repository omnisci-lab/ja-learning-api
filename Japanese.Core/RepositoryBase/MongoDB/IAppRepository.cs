using Japanese.Core.CommonModels;
using Japanese.Core.MongoDB;
using MongoDB.Bson;

namespace Japanese.Core.RepositoryBase.MongoDB;

public interface IAppRepository<TModel> where TModel : MongoDBModel
{
    Task<PagedResult<TModel>> GetPaginatedAsync(Pagination pagination);
    Task<TModel> GetAsync(ObjectId objectId);
}