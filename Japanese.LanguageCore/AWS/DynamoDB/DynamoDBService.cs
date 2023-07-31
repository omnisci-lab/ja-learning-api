using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2.DocumentModel;
using Amazon.DynamoDBv2;
using Japanese.Core.CommonModels;
using System.Reflection;

namespace Japanese.LanguageCore.AWS.DynamoDB;

public class DynamoDBService<TModel> : IDynamoDBService<TModel> where TModel : EntityBase
{
    private readonly IDynamoDBContext _context;

    public IDynamoDBContext Context => _context;

    public DynamoDBService(IAmazonDynamoDB dynamoDBClient)
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
        ScanOperationConfig scanConfig = new ScanOperationConfig();

        if (!string.IsNullOrEmpty(pagination.PaginationToken))
            scanConfig.PaginationToken = pagination.PaginationToken;

        scanConfig.Filter = filter;
        Search search = table.Scan(scanConfig);
        List<Document> data = await search.GetNextSetAsync();

        string? paginationToken = null;
        if (data.Count > pagination.PageSize)
        {
            data = data.Take(pagination.PageSize).ToList();

            Document lastDocument = data[data.Count - 1];
            PropertyInfo? hashKeyProperty = typeof(TModel).GetProperties().SingleOrDefault(x => x.GetCustomAttribute<DynamoDBHashKeyAttribute>() is not null);
            if (hashKeyProperty is null)
                throw new NullReferenceException();

            string attributeName = hashKeyProperty.GetCustomAttribute<DynamoDBHashKeyAttribute>()!.AttributeName;
            if (string.IsNullOrEmpty(attributeName))
                throw new NullReferenceException();

            paginationToken = $"{{ \"{attributeName}\": {{ \"S\": \"{data[data.Count - 1][attributeName]}\" }} }}";
        }
        else
        {
            paginationToken = search.PaginationToken;
        }

        return new PagedResult<TModel>
        {
            PaginationToken = paginationToken,
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

    public async Task SaveAsync(TModel item)
    {
        await _context.SaveAsync(item);
    }

    public async Task DeleteAsync(object? key)
    {
        await _context.DeleteAsync<TModel>(key);
    }

    public Task<int> CountAsync()
    {
        throw new NotImplementedException();
    }
}
