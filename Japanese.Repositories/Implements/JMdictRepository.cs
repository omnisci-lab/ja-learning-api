using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Japanese.LanguageCore.Repositories;
using Japanese.Models;
using Japanese.Repositories.Interfaces;
using ServiceStack.Aws.DynamoDb;

namespace Japanese.Repositories.Implements;

public class JMdictRepository : AppRepository<JMdictModel>, IJMdictRepository
{
    internal JMdictRepository(IAmazonDynamoDB dynamoDB, IDynamoDBContext context, IPocoDynamo pocoDynamo) 
        : base(dynamoDB, context, pocoDynamo)
    {
    }

    public async Task TestAsync()
    {
        var c = await CountAsync();
        //[{ "M":{ "appliesToKanji":{ "L":[{ "S":"*"}]},"text":{ "S":"がいこうとっけん"},"common":{ "BOOL":false},"tags":{ "L":[]} } }]
        var t = (await PocoDynamo.FromScan<JMdictModel>(x => x.Kana.Any(k => k.Text == "がいこうとっけん"))
            .ExecAsync()).First();

        await Task.CompletedTask;
    }
}
