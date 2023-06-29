using Amazon.DynamoDBv2;
using Japanese.Core.RepositoryBase;
using Japanese.Models;
using Japanese.Repositories.Interfaces;

namespace Japanese.Repositories.Implements;

public class KanjiRadicalRepository : AsyncRepository<KanjiRadicalModel>, IKanjiRadicalRepository
{
    internal KanjiRadicalRepository(AmazonDynamoDBClient client) 
        : base(client)
    {
    }
}