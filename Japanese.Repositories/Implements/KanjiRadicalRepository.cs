using Japanese.LanguageCore.AWS.Helpers;
using Japanese.LanguageCore.Repositories;
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