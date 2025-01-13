using Japanese.Models;
using Japanese.Repositories.Interfaces;
using khothemegiatot.WebApi.Repositories.MongoDB;
using MongoDB.Driver;

namespace Japanese.Repositories.Implements;

public class JMdictRepository : AppRepository<JMdictModel>, IJMdictRepository
{
    public JMdictRepository(IMongoDatabase database, string collectionName) 
        : base(database, collectionName)
    {
    }
}