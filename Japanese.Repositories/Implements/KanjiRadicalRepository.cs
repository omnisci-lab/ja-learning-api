using Amazon.DynamoDBv2;
using Japanese.LanguageCore.AWS.DynamoDB;
using Japanese.Models;
using Japanese.Repositories.Interfaces;

namespace Japanese.Repositories.Implements;

public class KanjiRadicalRepository : DynamoDBService<KanjiRadicalModel>, IKanjiRadicalRepository
{
    internal KanjiRadicalRepository(AmazonDynamoDBClient client) 
        : base(client)
    {
    }
}