using Japanese.LanguageCore.AWS.Helpers;
using Japanese.LanguageCore.Repositories;
using Japanese.Models;
using Japanese.Repositories.Interfaces;

namespace Japanese.Repositories.Implements;

public class JMdictRepository : AppRepository<JMdictModel>, IJMdictRepository
{
    public JMdictRepository(DynamoDBHelper dynamoDBHelper) 
        : base(dynamoDBHelper)
    {
    }
}