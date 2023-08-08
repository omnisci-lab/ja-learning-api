using Japanese.LanguageCore.AWS.DynamoDB;
using Japanese.LanguageCore.Repositories;
using Japanese.Models;
using Japanese.Repositories.Interfaces;

namespace Japanese.Repositories.Implements;

public class KanjiComponentRepository : AppRepository<KanjiComponentModel>, IKanjiComponentRepository
{
    public KanjiComponentRepository(IDynamoDBHelper dynamoDBHelper) 
        : base(dynamoDBHelper)
    {
    }
}