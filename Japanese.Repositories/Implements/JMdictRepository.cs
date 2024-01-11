using Japanese.Core.AWS.Helpers;
using Japanese.Core.RepositoryBase.DynamoDB;
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