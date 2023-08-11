using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Japanese.LanguageCore.Repositories;
using Japanese.Models;
using Japanese.Repositories.Interfaces;
using ServiceStack.Aws.DynamoDb;

namespace Japanese.Repositories.Implements;

public class AdditionalKanjiRepository : AppRepository<AdditionalKanjiModel>, IAdditionalKanjiRepository
{
    internal AdditionalKanjiRepository(IAmazonDynamoDB dynamoDB, IDynamoDBContext context, IPocoDynamo pocoDynamo) 
        : base(dynamoDB, context, pocoDynamo)
    {
    }

    public async Task<List<AdditionalKanjiModel>> GetItemsByIdsAsync(List<string> keys)
    {
        return await PocoDynamo.GetItemsAsync<AdditionalKanjiModel>(keys);
    }
}