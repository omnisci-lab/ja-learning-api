using Amazon.DynamoDBv2.DocumentModel;
using Amazon.DynamoDBv2;
using Newtonsoft.Json;

namespace Japanese.Core.DynamoDB;

public class DynamoDBExecution<T> : DynamoDBExecutionCore
    where T : class
{
    public DynamoDBExecution(IAmazonDynamoDB dynamoDBClient, string tableName)
        : base(dynamoDBClient, tableName)
    {
    }

    public async Task<List<T>> GetListAsync()
    {
        List<Document> documents = await ScanAsync();
        string json = documents.ToJson();

        return JsonConvert.DeserializeObject<List<T>>(json)!;
    }

    public async Task<T?> GetAsync(Primitive key)
    {
        Document document = await GetItemAsync(key);
        string json = document.ToJson();

        return JsonConvert.DeserializeObject<T>(json);
    }

    public async Task CreateAsync(T input)
    {
        string json = JsonConvert.SerializeObject(input);
        Document document = Document.FromJson(json);

        await CreateItemAsync(document);
    }

    public async Task UpdateAsync(T input)
    {
        string json = JsonConvert.SerializeObject(input);
        Document document = Document.FromJson(json);

        await UpdateItemAsync(document);
    }

    public async Task DeleteAsync(Primitive key)
    {
        await DeleteItemAsync(key);
    }
}
