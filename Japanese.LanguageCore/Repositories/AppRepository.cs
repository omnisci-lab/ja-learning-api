using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Japanese.Core.CommonModels;
using Japanese.LanguageCore.AWS.DynamoDB;
using ServiceStack.Aws.DynamoDb;

namespace Japanese.LanguageCore.Repositories;

public class AppRepository<TModel> : IAppRepository<TModel> where TModel : class
{
    private IDynamoDBContext _context;
    private IPocoDynamo _pocoDynamo;

    private AdvancedDynamoDBHelper<TModel> _advancedDynamoDBHelper;
    private DynamoDBHelper<TModel> _dynamoDbHelper;

    public AppRepository(IAmazonDynamoDB dynamoDB, IDynamoDBContext context, IPocoDynamo pocoDynamo)
    {
        _context = context;
        _pocoDynamo = pocoDynamo;

        _pocoDynamo.RegisterTable<TModel>();

        _advancedDynamoDBHelper = new AdvancedDynamoDBHelper<TModel>(_pocoDynamo);
        _dynamoDbHelper = new DynamoDBHelper<TModel>(context);
    }

    public IDynamoDBContext DynamoDBContext => _context;
    public IPocoDynamo PocoDynamo => _pocoDynamo;

    public AdvancedDynamoDBHelper<TModel> AdvancedDynamoDBHelper => _advancedDynamoDBHelper;
    public DynamoDBHelper<TModel> DynamoDbHelper => _dynamoDbHelper;

    public virtual async Task<long> CountAsync() => await _pocoDynamo.ScanItemCountAsync<TModel>();

    public virtual async Task DeleteAsync(object? key) => await _context.DeleteAsync<TModel>(key);

    public virtual async Task<TModel?> GetAsync(object? key) => await _context.LoadAsync<TModel>(key);

    public virtual async Task<List<TModel>> GetListAsync(int limit) => await _dynamoDbHelper.GetListAsync(limit);

    public virtual async Task<PagedResult<TModel>> GetPagedAsync(Pagination pagination)
        => await _dynamoDbHelper.GetPagedAsync(pagination);

    public virtual async Task SaveAsync(TModel item) => await _context.SaveAsync(item);
}