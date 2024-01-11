using Amazon.DynamoDBv2.DocumentModel;
using Japanese.Core.CommonModels;
using Japanese.Core.AWS.Helpers;
using Japanese.Models;
using Japanese.Repositories.Interfaces;
using Japanese.Core.RepositoryBase.DynamoDB;

namespace Japanese.Repositories.Implements;

public class SentenceRepository : AppRepository<SentenceModel>, ISentenceRepository
{
    public SentenceRepository(DynamoDBHelper dynamoDBHelper) 
        : base(dynamoDBHelper)
    {
    }

    public async Task<PagedResult<SentenceModel>> SearchByTextAsync(Pagination pagination)
    {
        ScanFilter scanFilter = new ScanFilter();
        scanFilter.AddCondition("text", ScanOperator.Contains, pagination.Keyword);

        return await Helper.GetPagedAsync<SentenceModel>(pagination/*, scanFilter*/);
    }

    public async Task<PagedResult<SentenceModel>> SearchByViMeaningAsync(Pagination pagination)
    {
        ScanFilter scanFilter = new ScanFilter();
        scanFilter.AddCondition("vi_meaning", ScanOperator.Contains, pagination.Keyword);

        return await Helper.GetPagedAsync<SentenceModel>(pagination/*, scanFilter*/);
    }
}