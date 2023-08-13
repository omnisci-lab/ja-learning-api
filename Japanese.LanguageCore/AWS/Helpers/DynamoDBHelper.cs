using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2.DocumentModel;
using Amazon.Runtime;
using Japanese.Core.CommonModels;
using System.Reflection;

namespace Japanese.LanguageCore.AWS.Helpers;

public class DynamoDBHelper : IDisposable
{
    private readonly IAmazonDynamoDB _dynamoDB;
    private readonly IDynamoDBContext _context;
    private bool disposedValue;

    public IAmazonDynamoDB DynamoDB => _dynamoDB;
    public IDynamoDBContext Context => _context;

    internal DynamoDBHelper(BasicAWSCredentials credentials, AmazonDynamoDBConfig config)
    {
        _dynamoDB = new AmazonDynamoDBClient(credentials, config);
        _context = new DynamoDBContext(_dynamoDB);
    }

    public async Task<PagedResult<TModel>> GetPagedAsync<TModel>(Pagination pagination, Expression? keyExpression = null, QueryFilter? filter = null)
        where TModel : class, new()
    {
        Table table = _context.GetTargetTable<TModel>();
        QueryOperationConfig queryConfig = new QueryOperationConfig() { Limit = pagination.PageSize };

        if (!string.IsNullOrEmpty(pagination.PaginationToken))
            queryConfig.PaginationToken = pagination.PaginationToken;

        queryConfig.KeyExpression = keyExpression ?? new Expression();
        queryConfig.Filter = filter ?? new QueryFilter();
        queryConfig.ConsistentRead = true;

        Search search = table.Query(queryConfig);
        List<Document> data = await search.GetNextSetAsync();

        return new PagedResult<TModel>
        {
            PaginationToken = search.PaginationToken,
            PageSize = pagination.PageSize,
            SearchBy = pagination.SearchBy,
            Keyword = pagination.Keyword,
            Items = _context.FromDocuments<TModel>(data).ToList()
        };
    }

    public async Task<List<TModel>> GetAllAsync<TModel>(Expression? keyExpression = null, QueryFilter? filter = null)
        where TModel : class, new()
    {
        Table table = _context.GetTargetTable<TModel>();
        QueryOperationConfig queryConfig = new QueryOperationConfig();

        queryConfig.KeyExpression = keyExpression ?? new Expression();
        queryConfig.Filter = filter ?? new QueryFilter();
        queryConfig.ConsistentRead = true;

        Search search = table.Query(queryConfig);
        List<Document> data = await search.GetNextSetAsync();

        return _context.FromDocuments<TModel>(data).ToList();
    }

    public async Task<List<TModel>> GetAllAsync<TModel>(ScanFilter filter) where TModel : class, new()
    {
        Table table = _context.GetTargetTable<TModel>();
        ScanOperationConfig scanConfig = new ScanOperationConfig();

        scanConfig.Filter = filter ?? new ScanFilter();

        Search search = table.Scan(scanConfig);
        List<Document> data = await search.GetNextSetAsync();

        return _context.FromDocuments<TModel>(data).ToList();
    }

    public async Task<List<TModel>> GetItemsWithLimitAsync<TModel>(int limit, Expression? keyExpression = null, QueryFilter? filter = null)
        where TModel : class, new()
    {
        Table table = _context.GetTargetTable<TModel>();
        QueryOperationConfig queryConfig = new QueryOperationConfig() { Limit = limit };

        queryConfig.KeyExpression = keyExpression ?? new Expression();
        queryConfig.Filter = filter ?? new QueryFilter();
        queryConfig.ConsistentRead = true;

        Search search = table.Query(queryConfig);
        List<Document> data = await search.GetNextSetAsync();

        return _context.FromDocuments<TModel>(data).ToList();
    }

    public async Task<List<TModel>> GetItemsAsync<TModel>(List<object> hashKeys) where TModel : class, new()
    {
        Table table = _context.GetTargetTable<TModel>();
        BatchGet<TModel> batchGet = _context.CreateBatchGet<TModel>();

        foreach (object hashKey in hashKeys)
        {
            batchGet.AddKey(hashKey);
        }

        await batchGet.ExecuteAsync();

        return batchGet.Results;
    }

    public async Task<PagedResult<TModel>> GetPagedAsync<TModel>(Pagination pagination, ScanFilter filter)
        where TModel : class, new()
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
            PropertyInfo[] properties = typeof(TModel).GetProperties();
            PropertyInfo? hashKeyProperty = properties.SingleOrDefault(x => x.GetCustomAttribute<DynamoDBHashKeyAttribute>() is not null);
            PropertyInfo? rangeKeyProperty = properties.SingleOrDefault(x => x.GetCustomAttribute<DynamoDBRangeKeyAttribute>() is not null);

            string? attributeName = hashKeyProperty?.GetCustomAttribute<DynamoDBHashKeyAttribute>()!.AttributeName;
            string? rangeKeyName = rangeKeyProperty?.GetCustomAttribute<DynamoDBRangeKeyAttribute>()!.AttributeName;

            if (!string.IsNullOrEmpty(attributeName) && !string.IsNullOrEmpty(rangeKeyName))
                paginationToken = $"{{ \"{attributeName}\": {{ \"S\": \"{data[data.Count - 1][attributeName]}\" }}, \"{rangeKeyName}\": {{ \"S\": \"{data[data.Count - 1][rangeKeyName]}\" }} }}";
            else if (!string.IsNullOrEmpty(attributeName))
                paginationToken = $"{{ \"{attributeName}\": {{ \"S\": \"{data[data.Count - 1][attributeName]}\" }} }}";
            else
                throw new NullReferenceException();
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

    public async Task<List<TModel>> GetListAsync<TModel>(int limit) where TModel : class, new()
    {
        ScanOperationConfig scanConfig = new ScanOperationConfig
        {
            Limit = limit
        };

        AsyncSearch<TModel> search = _context.FromScanAsync<TModel>(scanConfig);
        List<TModel> items = await search.GetNextSetAsync();

        return items;
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!disposedValue)
        {
            if (disposing)
            {
                _context.Dispose();
                _dynamoDB.Dispose();
            }

            disposedValue = true;
        }
    }

    public void Dispose()
    {
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }
}
