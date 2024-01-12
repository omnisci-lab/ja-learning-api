using Japanese.Core.RepositoryBase.MongoDB;
using Japanese.Models;
using Japanese.Repositories.Interfaces;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace Japanese.Repositories.Implements;

public class KanjiComponentRepository : AppRepository<KanjiComponentModel>, IKanjiComponentRepository
{
    public KanjiComponentRepository(IMongoDatabase database, string collectionName) 
        : base(database, collectionName)
    {
    }

    public async Task<KanjiComponentModel> GetByLiteralAsync(string literal)
    {
        return await Collection.AsQueryable().Where(x => x.Literal == literal).SingleOrDefaultAsync();
    }
}