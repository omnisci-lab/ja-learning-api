using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Japanese.LanguageCore.Repositories;
using Japanese.Models;
using Japanese.Repositories.Interfaces;
using ServiceStack.Aws.DynamoDb;

namespace Japanese.Repositories.Implements;

public class Kanjidic2ExtensionRepository : AppRepository<Kanjidic2ExtensionModel>, Interfaces.IKanjidic2ExtensionRepository
{
    internal Kanjidic2ExtensionRepository(IAmazonDynamoDB dynamoDB, IDynamoDBContext context, IPocoDynamo pocoDynamo) 
        : base(dynamoDB, context, pocoDynamo)
    {
    }

    public async Task<List<Kanjidic2ExtensionModel>> GetItemsByIdsAsync(List<string> keys)
    {
        return await PocoDynamo.GetItemsAsync<Kanjidic2ExtensionModel>(keys);
    }
}