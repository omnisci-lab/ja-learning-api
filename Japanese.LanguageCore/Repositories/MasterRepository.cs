using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Amazon.Runtime;
using ServiceStack.Aws.DynamoDb;

namespace Japanese.LanguageCore.Repositories;

public class MasterRepository
{
    private readonly IAmazonDynamoDB _client;
    private IDynamoDBContext _context;
    private IPocoDynamo _pocoDynamo;

    public MasterRepository(BasicAWSCredentials basicAWSCredentials, AmazonDynamoDBConfig dynamoDBConfig)
    {
        _client = new AmazonDynamoDBClient(basicAWSCredentials, dynamoDBConfig);

        _context = new DynamoDBContext(_client);
        _pocoDynamo = new PocoDynamo(_client);
    }

    public IAmazonDynamoDB Client => _client;

    public IDynamoDBContext Context => _context;
    public IPocoDynamo PocoDynamo => _pocoDynamo;
}