using Japanese.Core.AWS.Helpers;
using Japanese.Core.RepositoryBase.DynamoDB;
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