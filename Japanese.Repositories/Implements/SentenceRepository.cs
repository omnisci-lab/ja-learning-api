using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DocumentModel;
using Japanese.Core.CommonModels;
using Japanese.LanguageCore.AWS.DynamoDB;
using Japanese.Models;
using Japanese.Repositories.Interfaces;

namespace Japanese.Repositories.Implements;

public class SentenceRepository : DynamoDBService<SentenceModel>, ISentenceRepository
{
    internal SentenceRepository(AmazonDynamoDBClient client) 
        : base(client)
    {

    }

    public async Task<PagedResult<SentenceModel>> SearchByTextAsync(Pagination pagination)
    {
        ScanFilter scanFilter = new ScanFilter();
        scanFilter.AddCondition("text", ScanOperator.Contains, pagination.Keyword);

        return await GetPagedAsync(pagination, scanFilter);
    }

    public async Task<PagedResult<SentenceModel>> SearchByViMeaningAsync(Pagination pagination)
    {
        ScanFilter scanFilter = new ScanFilter();
        scanFilter.AddCondition("vi_meaning", ScanOperator.Contains, pagination.Keyword);

        return await GetPagedAsync(pagination, scanFilter);
    }
}