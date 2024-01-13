using Japanese.Core.RepositoryBase.MongoDB;
using Japanese.Models;
using Japanese.Repositories.Interfaces;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace Japanese.Repositories.Implements;

public class KanaRepository : AppRepository<KanaModel>, IKanaRepository
{
    public KanaRepository(IMongoDatabase database, string collectionName) 
        : base(database, collectionName)
    {
    }

    public async Task<KanaModel> GetByCharacterAsync(string character)
    {
        return await Collection.AsQueryable().Where(x => x.Character == character)
            .SingleOrDefaultAsync();
    }

    public async Task<List<KanaModel>> GetListAsync(string kanaType)
    {
        return await Collection.AsQueryable().Where(x => x.KanaType == kanaType).ToListAsync();
    }
}