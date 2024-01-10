using Japanese.Core.AWS.Helpers;
using Japanese.Core.RepositoryBase;
using Japanese.Models;
using Japanese.Repositories.Interfaces;

namespace Japanese.Repositories.Implements;

public class Kanjidic2Repository : AppRepository<Kanjidic2Model>, IKanjidic2Repository
{
    public Kanjidic2Repository(DynamoDBHelper dynamoDBHelper) 
        : base(dynamoDBHelper)
    {

    }
}