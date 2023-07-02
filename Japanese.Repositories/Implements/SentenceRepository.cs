using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2.DocumentModel;
using Japanese.Core.RepositoryBase;
using Japanese.Models;
using Japanese.Repositories.Interfaces;

namespace Japanese.Repositories.Implements;

public class SentenceRepository : AsyncRepository<SentenceModel>, ISentenceRepository
{
    internal SentenceRepository(AmazonDynamoDBClient client) 
        : base(client)
    {
    }

    public async Task<List<SentenceModel>> SearchAsync(string searchBy, string keyword)
    {
        ScanFilter scanFilter = new ScanFilter();
        if(searchBy == "vi-meanings")
            scanFilter.AddCondition("vi_meanings", ScanOperator.Contains, keyword);

        ScanOperationConfig scanConfig = new ScanOperationConfig { Filter = scanFilter };
        AsyncSearch<SentenceModel> search = Context.FromScanAsync<SentenceModel>(scanConfig);

        return await search.GetNextSetAsync();
    }
}