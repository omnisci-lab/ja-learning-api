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

    public async Task<Pagination<TModel>> GetPagedAsync(Pagination pagination)
    {
        Table table = _context.GetTargetTable<TModel>();

        ScanOperationConfig scanConfig = new ScanOperationConfig() { Limit = pagination.PageSize };

        if (!string.IsNullOrEmpty(pagination.PaginationToken))
            scanConfig.PaginationToken = pagination.PaginationToken;

        Search search = table.Scan(scanConfig);
        List<Document> data = await search.GetNextSetAsync();

        List<TModel> items = _context.FromDocuments<TModel>(data).ToList();

        return new Pagination<TModel>
        {
            PaginationToken = search.PaginationToken,
            Items = items
        };
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

    public async Task SaveItemAsync(TModel item)
    {
        await _context.SaveAsync(item);
    }

    public async Task DeleteItemAsync(object? key)
    {
        await _context.DeleteAsync<TModel>(key);
    }

    public async Task<int> CountItemsAsync()
    {
        ScanOperationConfig operationConfig = new ScanOperationConfig
        {
            Select = SelectValues.Count
        };

        //_context.FromScanAsync(operationConfig);

        AsyncSearch<int> search = _context.FromScanAsync<int>(operationConfig);
        List<int> a = await search.GetNextSetAsync();

        return 0;
    }
}
