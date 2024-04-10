using Japanese.Core.RepositoryBase.MongoDB;
using Japanese.Models;
using Japanese.Repositories.Interfaces;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace Japanese.Repositories.Implements;

public class KanjiRepository : AppRepository<KanjiModel>, IKanjiRepository
{
    public KanjiRepository(IMongoDatabase database, string collectionName) 
        : base(database, collectionName)
    {
    }

    public async Task<KanjiModel> GetByLiteralAsync(string literal)
    {
        return await Collection.AsQueryable()
            .Where(x => x.Literal == literal).SingleOrDefaultAsync();
    }
}
