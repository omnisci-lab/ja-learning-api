using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2.DocumentModel;
using Japanese.Core.RepositoryBase;
using Japanese.Models;
using Japanese.Repositories.Interfaces;

namespace Japanese.Repositories.Implements;

public class KanjiRepository : AsyncRepository<KanjiModel>, IKanjiRepository
{
    private readonly AmazonDynamoDBClient _client;

    public KanjiRepository(AmazonDynamoDBClient client) 
        : base(client)
    {
        _client = client;
    }

    public async Task<List<KanjiModel>> GetListByJlptAsync(int? jlpt)
    {
        ScanFilter scanFilter = new ScanFilter();
        scanFilter.AddCondition("jlpt", ScanOperator.Equal, jlpt);

        ScanOperationConfig scanConfig = new ScanOperationConfig { Filter = scanFilter };
        AsyncSearch<KanjiModel> search = Context.FromScanAsync<KanjiModel>(scanConfig);

        return await search.GetNextSetAsync();
    }
}
