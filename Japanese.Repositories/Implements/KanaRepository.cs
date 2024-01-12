using Japanese.Core.AWS.Helpers;
using Japanese.Core.RepositoryBase.MongoDB;
using Japanese.Models;
using Japanese.Repositories.Interfaces;
using MongoDB.Driver;

namespace Japanese.Repositories.Implements;

public class KanaRepository : AppRepository<KanaModel>, IKanaRepository
{
    public KanaRepository(IMongoDatabase database, string collectionName) 
        : base(database, collectionName)
    {
    }
}