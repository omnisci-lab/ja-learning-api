using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Japanese.Core.CommonModels;
using Japanese.Core.AWS.Helpers;

namespace Japanese.Core.RepositoryBase.DynamoDB;

public class AppRepository<TModel> : IAppRepository<TModel> where TModel : class, new()
{
    private readonly DynamoDBHelper _dynamoDbHelper;

    public AppRepository(DynamoDBHelper dynamoDBHelper)
    {
        _dynamoDbHelper = dynamoDBHelper;
    }

    public DynamoDBHelper Helper => _dynamoDbHelper;
    public IAmazonDynamoDB DynamoClient => _dynamoDbHelper.DynamoDB;
    public IDynamoDBContext Context => _dynamoDbHelper.Context;

    public virtual async Task DeleteAsync(object? key) => await _dynamoDbHelper.Context.DeleteAsync<TModel>(key);

    public virtual async Task<TModel?> GetAsync(object? key) => await _dynamoDbHelper.Context.LoadAsync<TModel>(key);

    public virtual async Task<List<TModel>> GetListAsync(int limit) => await _dynamoDbHelper.GetListAsync<TModel>(limit);

    public virtual async Task<PagedResult<TModel>> GetPagedAsync(Pagination pagination)
        => await _dynamoDbHelper.GetPagedAsync<TModel>(pagination);

    public virtual async Task SaveAsync(TModel item) => await _dynamoDbHelper.Context.SaveAsync(item);
}