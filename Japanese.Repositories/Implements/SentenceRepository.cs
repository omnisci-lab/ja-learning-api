using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2.DocumentModel;
using Japanese.Core.CommonModels;
using Japanese.LanguageCore.Repositories;
using Japanese.Models;
using Japanese.Repositories.Interfaces;
using ServiceStack.Aws.DynamoDb;

namespace Japanese.Repositories.Implements;

public class SentenceRepository : AppRepository<SentenceModel>, ISentenceRepository
{
    internal SentenceRepository(IAmazonDynamoDB dynamoDB, IDynamoDBContext context, IPocoDynamo pocoDynamo) 
        : base(dynamoDB, context, pocoDynamo)
    {
    }

    public async Task<PagedResult<SentenceModel>> SearchByTextAsync(Pagination pagination)
    {
        ScanFilter scanFilter = new ScanFilter();
        scanFilter.AddCondition("text", ScanOperator.Contains, pagination.Keyword);

        return await DynamoDbHelper.GetPagedAsync(pagination, scanFilter);
    }

    public async Task<PagedResult<SentenceModel>> SearchByViMeaningAsync(Pagination pagination)
    {
        ScanFilter scanFilter = new ScanFilter();
        scanFilter.AddCondition("vi_meaning", ScanOperator.Contains, pagination.Keyword);

        return await DynamoDbHelper.GetPagedAsync(pagination, scanFilter);
    }
}