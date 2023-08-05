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

    public async Task<PagedResult<JlptKanjiModel>> GetJlptN4KanjiAsync(Pagination pagination)
    {
        int jlptLevel = 0;
        if (!int.TryParse(pagination.Keyword, out jlptLevel))
            throw new InvalidCastException();

        ScanFilter scanFilter = new ScanFilter();

        scanFilter.AddCondition("jlpt_level", ScanOperator.Equal, jlptLevel);

        return await DynamoDbHelper.GetPagedAsync(pagination, scanFilter);
    }
}