using Japanese.LanguageCore.AWS.Helpers;
using Japanese.LanguageCore.Repositories;
using Japanese.Models;
using Japanese.Repositories.Interfaces;

namespace Japanese.Repositories.Implements;

public class KanaRepository : AppRepository<KanaModel>, IKanaRepository
{
    public KanaRepository(DynamoDBHelper dynamoDBHelper) 
        : base(dynamoDBHelper)
    {
    }
}