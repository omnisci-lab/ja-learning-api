using Amazon.DynamoDBv2.DocumentModel;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Japanese.Core.CommonModels;

namespace Japanese.Core.DynamoDB;

public class DynamoDBExecution<TModel> : IDynamoDBExecution<TModel>
    where TModel : EntityBase
{
    private readonly IDynamoDBContext _context;

    public IDynamoDBContext Context => _context;

    public DynamoDBExecution(IAmazonDynamoDB dynamoDBClient)
    {
        _context = new DynamoDBContext(dynamoDBClient);
    }

    public async Task<List<TModel>> GetPagedItems(int pageSize)
    {
        string token = "";

        var queryConfig = new QueryOperationConfig
        {
            Limit = pageSize,
            PaginationToken = token,
        };

        AsyncSearch<TModel> search = _context.FromQueryAsync<TModel>(queryConfig);
        //search.Pa
        //var results = await search.GetNextSetAsync();

        //return results.ToList();

        return null;
    }

    public async Task<List<TModel>> GetListAsync(int limit)
    {
        ScanOperationConfig scanConfig = new ScanOperationConfig
        {
            Limit = limit
        };

        AsyncSearch<TModel> search = _context.FromScanAsync<TModel>(scanConfig);
        List<TModel> items = await search.GetNextSetAsync();

        return items;
    }

    public async Task<TModel?> GetAsync(object? key)
    {
        return await _context.LoadAsync<TModel>(key);
    }

    public async Task SaveItem(TModel item)
    {
        await _context.SaveAsync(item);
    }

    public async Task DeleteItem(object? key)
    {
        await _context.DeleteAsync<TModel>(key);
    }

    public async Task<int> CountItems()
    {
        ScanOperationConfig operationConfig = new ScanOperationConfig
        {
            Select = SelectValues.Count
        };

        var a = _context.FromScanAsync<TModel>(operationConfig);

        return 0;
    }
}
