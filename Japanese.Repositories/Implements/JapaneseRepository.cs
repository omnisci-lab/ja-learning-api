using Amazon.DynamoDBv2;
using Amazon.Runtime;
using Japanese.Repositories.Interfaces;

namespace Japanese.Repositories.Implements;

public class JapaneseRepository : IJapaneseRepository
{
    private readonly AmazonDynamoDBClient _client;

    public JapaneseRepository(BasicAWSCredentials basicAWSCredentials, AmazonDynamoDBConfig dynamoDBConfig)
    {
        _client = new AmazonDynamoDBClient(basicAWSCredentials, dynamoDBConfig);
    }

    public IKanjiRepository KanjiRepository => new KanjiRepository(_client);

    public IKanjiRadicalRepository KanjiRadicalRepository => new KanjiRadicalRepository(_client);

    public ISentenceRepository SentenceRepository => new SentenceRepository(_client);

    public IUserRepository UserRepository =>  new UserRepository(_client);
}
