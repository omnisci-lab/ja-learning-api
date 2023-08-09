using Amazon.DynamoDBv2.DocumentModel;
using Japanese.Core.CommonModels;
using Japanese.LanguageCore.AWS.Helpers;
using Japanese.LanguageCore.Repositories;
using Japanese.Models;
using Japanese.Repositories.Interfaces;

namespace Japanese.Repositories.Implements;

public class KankenRepository : AppRepository<KankenModel>, IKankenRepository
{
    public KankenRepository(DynamoDBHelper dynamoDBHelper) 
        : base(dynamoDBHelper)
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

        return await Helper.GetPagedAsync<KankenModel>(pagination, keyExpression);
    }
}