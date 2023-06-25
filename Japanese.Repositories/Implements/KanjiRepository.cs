using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DocumentModel;
using Japanese.Core.RepositoryBase;
using Japanese.Models;
using Japanese.Repositories.Interfaces;

namespace Japanese.Repositories.Implements;

public class KanjiRepository : AsyncRepository<KanjiModel>, IKanjiRepository
{
    private readonly AmazonDynamoDBClient _client;
    private readonly string _tableName;

    public KanjiRepository(AmazonDynamoDBClient client, string tableName) 
        : base(client, tableName)
    {
        _client = client;
        _tableName = tableName;
    }

    public async Task<List<KanjiModel>> SearchAsync()
    {
        Table table = Table.LoadTable(_client, _tableName);

        return null;
    }
}
