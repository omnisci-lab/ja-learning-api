using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Japanese.LanguageCore.Repositories;
using Japanese.Models;
using Japanese.Repositories.Interfaces;
using ServiceStack.Aws.DynamoDb;

namespace Japanese.Repositories.Implements;

public class Kanjidic2Repository : AppRepository<Kanjidic2Model>, IKanjidic2Repository
{
    public Kanjidic2Repository(IAmazonDynamoDB dynamoDB, IDynamoDBContext context, IPocoDynamo pocoDynamo) 
        : base(dynamoDB, context, pocoDynamo)
    {
    }

    public override async Task<Kanjidic2Model?> GetAsync(object? key)
    {
        return await PocoDynamo.GetItemAsync<Kanjidic2Model>(key);
    }
}