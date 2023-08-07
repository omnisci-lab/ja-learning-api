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
        Expression keyExpression = new Expression
        {
            ExpressionStatement = "kanken_level = :pkval",
            ExpressionAttributeValues = new Dictionary<string, DynamoDBEntry>
            {
                { ":pkval", pagination.Keyword }
            }
        };

        return await DynamoDbHelper.GetPagedAsync(pagination, keyExpression);
    }
}
