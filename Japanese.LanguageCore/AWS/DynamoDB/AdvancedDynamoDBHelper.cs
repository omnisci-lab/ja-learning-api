using ServiceStack.Aws.DynamoDb;
using Japanese.Core.CommonModels;
using System.Linq.Expressions;

namespace Japanese.LanguageCore.AWS.DynamoDB;

public class AdvancedDynamoDBHelper<TModel> where TModel : EntityBase
{
    private readonly IPocoDynamo _pocoDynamo;

    public AdvancedDynamoDBHelper(IPocoDynamo pocoDynamo)
    {
        _pocoDynamo = pocoDynamo;
    }

    public async Task<TModel?> GetByAsync(Expression<Func<TModel, bool>> expression)
    {
        ScanExpression<TModel> scanExpression = _pocoDynamo.FromScan<TModel>(expression);
        scanExpression.Limit = 1;
        return (await scanExpression.ExecAsync()).First();
    }

    public async Task<long> CountAsync()
    {
        return await _pocoDynamo.ScanItemCountAsync<TModel>();
    }
}