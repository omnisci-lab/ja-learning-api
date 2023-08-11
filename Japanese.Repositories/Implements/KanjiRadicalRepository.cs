using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Japanese.LanguageCore.AWS.DynamoDB;
using Japanese.LanguageCore.Repositories;
using Japanese.Models;
using Japanese.Repositories.Interfaces;
using ServiceStack.Aws.DynamoDb;

namespace Japanese.Repositories.Implements;

public class KanjiRadicalRepository : AppRepository<KanjiRadicalModel>, IKanjiRadicalRepository
{
    internal KanjiRadicalRepository(IAmazonDynamoDB dynamoDB, IDynamoDBContext context, IPocoDynamo pocoDynamo) 
        : base(dynamoDB, context, pocoDynamo)
    {
    }
}