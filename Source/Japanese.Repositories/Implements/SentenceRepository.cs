using Japanese.Models;
using Japanese.Repositories.Interfaces;
using Japanese.Core.RepositoryBase.MongoDB;
using MongoDB.Driver;

namespace Japanese.Repositories.Implements;

public class SentenceRepository : AppRepository<SentenceModel>, ISentenceRepository
{
    public SentenceRepository(IMongoDatabase database, string collectionName) 
        : base(database, collectionName)
    {
    }
}