using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DocumentModel;
using Japanese.Core.CommonModels;

namespace Japanese.LanguageCore.AWS.DynamoDB;

public interface IDynamoDBHelper : IDisposable
{
    IAmazonDynamoDB DynamoDB { get; }
    IDynamoDBContext Context { get; }

    Task<PagedResult<TModel>> GetPagedAsync<TModel>(Pagination pagination, Expression? keyExpression = null, QueryFilter? filter = null) where TModel : class, new();
    Task<List<TModel>> GetAllAsync<TModel>(Expression? keyExpression = null, QueryFilter? filter = null) where TModel : class, new();
    Task<List<TModel>> GetAllAsync<TModel>(ScanFilter filter) where TModel : class, new();
    Task<List<TModel>> GetItemsWithLimitAsync<TModel>(int limit, Expression? keyExpression = null, QueryFilter? filter = null)where TModel : class, new();
    Task<List<TModel>> GetItemsAsync<TModel>(List<object> hashKeys) where TModel : class, new();
    Task<PagedResult<TModel>> GetPagedAsync<TModel>(Pagination pagination, ScanFilter filter)where TModel : class, new();
    Task<List<TModel>> GetListAsync<TModel>(int limit) where TModel : class, new();
}