using Amazon.DynamoDBv2.DocumentModel;
using Japanese.Core.CommonModels;
using Japanese.LanguageCore.AWS.Helpers;
using Japanese.LanguageCore.Repositories;
using Japanese.Models;
using Japanese.Repositories.Interfaces;

namespace Japanese.Repositories.Implements;

public class JlptKanjiRepository : AppRepository<JlptKanjiModel>, IJlptKanjiRepository
{
    public JlptKanjiRepository(DynamoDBHelper dynamoDBHelper) 
        : base(dynamoDBHelper)
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

        return await Helper.GetPagedAsync<JlptKanjiModel>(pagination, keyExpression);
    }
}