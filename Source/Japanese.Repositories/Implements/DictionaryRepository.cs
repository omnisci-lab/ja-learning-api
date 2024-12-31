using Japanese.Core.RepositoryBase.MongoDB;
using Japanese.Models;
using Japanese.Repositories.Interfaces;
using MongoDB.Driver;

namespace Japanese.Repositories.Implements;

public class DictionaryRepository : AppRepository<DictionaryModel>, IDictionaryRepository
{
    public DictionaryRepository(IMongoDatabase database, string collectionName) 
        : base(database, collectionName)
    {
    }
}
