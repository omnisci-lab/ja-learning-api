using Japanese.Core.RepositoryBase.MongoDB;
using Japanese.Models;
using Japanese.Repositories.Interfaces;
using MongoDB.Driver;

namespace Japanese.Repositories.Implements;

public class KanjiRadicalRepository : AppRepository<KanjiRadicalModel>, IKanjiRadicalRepository
{
    public KanjiRadicalRepository(IMongoDatabase database, string collectionName) 
        : base(database, collectionName)
    {
    }
}