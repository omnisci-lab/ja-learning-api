using Japanese.Models;
using Japanese.Repositories.Interfaces;
using MongoDB.Driver;
using khothemegiatot.WebApi.Repositories.MongoDB;

namespace Japanese.Repositories.Implements;

public class SentenceRepository : AppRepository<SentenceModel>, ISentenceRepository
{
    public SentenceRepository(IMongoDatabase database, string collectionName) 
        : base(database, collectionName)
    {
    }
}