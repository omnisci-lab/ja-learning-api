using Japanese.Models;
using Japanese.Repositories.Interfaces;
using khothemegiatot.WebApi.Repositories.MongoDB;
using MongoDB.Driver;

namespace Japanese.Repositories.Implements;

public class DictionaryRepository : AppRepository<DictionaryModel>, IDictionaryRepository
{
    public DictionaryRepository(IMongoDatabase database, string collectionName) 
        : base(database, collectionName)
    {
    }
}
