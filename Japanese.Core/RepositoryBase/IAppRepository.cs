using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2;
using Japanese.Core.AWS.Helpers;
using Japanese.Core.CommonModels;

namespace Japanese.Core.RepositoryBase;

public interface IAppRepository<TModel> where TModel : class, new()
{
    DynamoDBHelper Helper { get; }
    IAmazonDynamoDB DynamoClient { get; }
    IDynamoDBContext Context { get; }

    Task<PagedResult<TModel>> GetPagedAsync(Pagination pagination);
    Task<List<TModel>> GetListAsync(int limit);
    Task<TModel?> GetAsync(object? key);
    Task SaveAsync(TModel item);
    Task DeleteAsync(object? key);
}