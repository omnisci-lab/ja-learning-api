using Japanese.Core.RepositoryBase.MongoDB;
using Japanese.Models;
using Japanese.Repositories.Interfaces;
using MongoDB.Driver;

namespace Japanese.Repositories.Implements;

public class CommonWordRepository : AppRepository<CommonWordModel>, ICommonWordRepository
{
    public CommonWordRepository(IMongoDatabase database, string collectionName) 
        : base(database, collectionName)
    {
    }
}