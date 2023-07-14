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

    public async Task<PagedResult<TModel>> GetPagedAsync(Pagination pagination)
    {
        Table table = _context.GetTargetTable<TModel>();

        ScanOperationConfig scanConfig = new ScanOperationConfig() { Limit = pagination.PageSize };

        if (!string.IsNullOrEmpty(pagination.PaginationToken))
            scanConfig.PaginationToken = pagination.PaginationToken;

        Search search = table.Scan(scanConfig);
        List<Document> data = await search.GetNextSetAsync();

        return new PagedResult<TModel>
        {
            PaginationToken = search.PaginationToken,
            PageSize = pagination.PageSize,
            Items = _context.FromDocuments<TModel>(data).ToList()
        };
    }

    protected async Task<PagedResult<TModel>> GetPagedAsync(Pagination pagination, ScanFilter filter)
    {
        Table table = _context.GetTargetTable<TModel>();
        ScanOperationConfig scanConfig = new ScanOperationConfig() { Limit = pagination.PageSize };

        if (!string.IsNullOrEmpty(pagination.PaginationToken))
            scanConfig.PaginationToken = pagination.PaginationToken;

        scanConfig.Filter = filter;
        Search search = table.Scan(scanConfig);
        List<Document> data = await search.GetNextSetAsync();

        pagination.PaginationToken = search.PaginationToken;

        return new PagedResult<TModel>
        {
            PaginationToken = search.PaginationToken,
            PageSize = pagination.PageSize,
            SearchBy = pagination.SearchBy,
            Keyword = pagination.Keyword,
            Items = _context.FromDocuments<TModel>(data).ToList()
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
