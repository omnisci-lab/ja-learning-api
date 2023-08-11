using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2.DocumentModel;
using Japanese.Core.CommonModels;
using Japanese.LanguageCore.Repositories;
using Japanese.Models;
using Japanese.Repositories.Interfaces;
using ServiceStack.Aws.DynamoDb;

namespace Japanese.Repositories.Implements;

public class JlptKanjiRepository : AppRepository<JlptKanjiModel>, IJlptKanjiRepository
{
    internal JlptKanjiRepository(IAmazonDynamoDB dynamoDB, IDynamoDBContext context, IPocoDynamo pocoDynamo) 
        : base(dynamoDB, context, pocoDynamo)
    {
    }

    public async Task<PagedResult<JlptKanjiModel>> GetJlptKanjiAsync(Pagination pagination)
    {
        int jlptLevel = 0;
        if (!int.TryParse(pagination.Keyword, out jlptLevel))
            throw new InvalidCastException();

        Expression keyExpression = new Expression
        {
            ExpressionStatement = "jlpt_level = :pkval",
            ExpressionAttributeValues = new Dictionary<string, DynamoDBEntry>
            {
                { ":pkval", jlptLevel }
            }
        };

        return await DynamoDbHelper.GetPagedAsync(pagination, keyExpression);
    }
}