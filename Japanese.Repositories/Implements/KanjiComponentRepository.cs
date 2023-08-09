using Japanese.LanguageCore.AWS.Helpers;
using Japanese.LanguageCore.Repositories;
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