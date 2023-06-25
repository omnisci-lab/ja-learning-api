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

    public IKanjiRepository KanjiRepository => new KanjiRepository(_client, "Kanji");
}
