using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DocumentModel;

namespace Japanese.Core.DynamoDB;

public class DynamoDBExecutionCore
{
    private readonly IAmazonDynamoDB _dynamoDBClient;
    private readonly string _tableName;

    public DynamoDBExecutionCore(IAmazonDynamoDB dynamoDBClient, string tableName)
    {
        _dynamoDBClient = dynamoDBClient;
        _tableName = tableName;
    }

    public async Task CreateItemAsync(Document document)
    {
        Table table = Table.LoadTable(_dynamoDBClient, _tableName);
        await table.PutItemAsync(document);
    }

    public async Task<Document> GetItemAsync(Primitive key)
    {
        Table table = Table.LoadTable(_dynamoDBClient, _tableName);
        return await table.GetItemAsync(key);
    }

    public async Task UpdateItemAsync(Document document)
    {
        Table table = Table.LoadTable(_dynamoDBClient, _tableName);
        await table.UpdateItemAsync(document);
    }

    public async Task DeleteItemAsync(Primitive key)
    {
        Table table = Table.LoadTable(_dynamoDBClient, _tableName);
        await table.DeleteItemAsync(key);
    }

    public async Task<List<Document>> ScanAsync()
    {
        Table table = Table.LoadTable(_dynamoDBClient, _tableName);
        ScanFilter scanFilter = new ScanFilter();
        Search search = table.Scan(scanFilter);

        List<Document> items = new List<Document>();

        do
        {
            items.AddRange(await search.GetNextSetAsync());
        } while (!search.IsDone);

        return items;
    }

    public async Task<List<Document>> QueryAsync(string attributeName, string attributeValue)
    {
        Table table = Table.LoadTable(_dynamoDBClient, _tableName);
        QueryFilter queryFilter = new QueryFilter(attributeName, QueryOperator.Equal, attributeValue);
        Search search = table.Query(queryFilter);

        List<Document> items = new List<Document>();

        do
        {
            items.AddRange(await search.GetNextSetAsync());
        } while (!search.IsDone);

        return items;
    }
}