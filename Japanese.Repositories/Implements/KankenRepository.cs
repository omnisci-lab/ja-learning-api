using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2.DocumentModel;
using Japanese.Core.CommonModels;
using Japanese.LanguageCore.Repositories;
using Japanese.Models;
using Japanese.Repositories.Interfaces;
using ServiceStack.Aws.DynamoDb;

namespace Japanese.Repositories.Implements;

public class KankenRepository : AppRepository<KankenModel>, IKankenRepository
{
    internal KankenRepository(IAmazonDynamoDB dynamoDB, IDynamoDBContext context, IPocoDynamo pocoDynamo) 
        : base(dynamoDB, context, pocoDynamo)
    {
    }

    public async Task<PagedResult<KankenModel>> GetKanjiByKankenLevel(Pagination pagination)
    {
        int kankenLevel = 0;
        if (!int.TryParse(pagination.Keyword, out kankenLevel))
            throw new InvalidCastException();

        Expression keyExpression = new Expression
        {
            ExpressionStatement = "kanken_level = :pkval",
            ExpressionAttributeValues = new Dictionary<string, DynamoDBEntry>
            {
                { ":pkval", kankenLevel }
            }
        };

        return await DynamoDbHelper.GetPagedAsync(pagination, keyExpression);
    }
}
