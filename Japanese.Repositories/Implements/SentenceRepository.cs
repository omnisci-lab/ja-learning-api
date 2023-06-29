using Amazon.DynamoDBv2;
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
}