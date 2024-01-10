using Japanese.Core.AWS.Helpers;
using Japanese.Core.RepositoryBase;
using Japanese.Models;
using Japanese.Repositories.Interfaces;

namespace Japanese.Repositories.Implements;

public class KanjiComponentRepository : AppRepository<KanjiComponentModel>, IKanjiComponentRepository
{
    public KanjiComponentRepository(DynamoDBHelper dynamoDBHelper) 
        : base(dynamoDBHelper)
    {
    }
}