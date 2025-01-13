using Japanese.Models;
using Japanese.Repositories.Interfaces;
using khothemegiatot.WebApi.Repositories.MongoDB;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace Japanese.Repositories.Implements;

public class KanjiRadicalRepository : AppRepository<KanjiRadicalModel>, IKanjiRadicalRepository
{
    public KanjiRadicalRepository(IMongoDatabase database, string collectionName) 
        : base(database, collectionName)
    {
    }

    public async Task<KanjiRadicalModel> GetByCharacterAsync(string character)
    {
        return await Collection.AsQueryable().Where(x => x.Character == character)
            .SingleOrDefaultAsync();
    }
}