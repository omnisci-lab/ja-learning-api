using Japanese.Core.AWS.Helpers;
using Japanese.Core.RepositoryBase.DynamoDB;
using Japanese.Models;
using Japanese.Repositories.Interfaces;

namespace Japanese.Repositories.Implements;

public class KanjiRadicalRepository : AppRepository<KanjiRadicalModel>, IKanjiRadicalRepository
{
    public KanjiRadicalRepository(DynamoDBHelper dynamoDBHelper) 
        : base(dynamoDBHelper)
    {
    }
}