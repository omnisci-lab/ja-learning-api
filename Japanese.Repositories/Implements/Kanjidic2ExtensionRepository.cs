using Japanese.Core.CommonModels;
using Japanese.Core.RepositoryBase.MongoDB;
using Japanese.Models;
using Japanese.Repositories.Interfaces;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace Japanese.Repositories.Implements;

public class Kanjidic2ExtensionRepository : AppRepository<Kanjidic2ExtensionModel>, IKanjidic2ExtensionRepository
{
    public Kanjidic2ExtensionRepository(IMongoDatabase database, string collectionName) 
        : base(database, collectionName)
    {

    }

    public async Task<Kanjidic2ExtensionModel> GetByLiteralAsync(string literal)
    {
        return await Collection.AsQueryable()
            .Where(x => x.Literal == literal).SingleOrDefaultAsync();
    }

    public async Task<List<Kanjidic2ExtensionModel>> GetItemsByLiteralsAsync(List<string?> literals)
    {
        return await Collection.AsQueryable().Where(x => literals.Contains(x.Literal)).ToListAsync();
    }

    public async Task<PagedResult<Kanjidic2ExtensionModel>> GetKanjiByJlptAsync(Pagination pagination)
    {
        int jlptLevel = 0;
        if (!int.TryParse(pagination.FilterValue, out jlptLevel))
            throw new Exception("");

        PagedResult<Kanjidic2ExtensionModel> pagedResult = new PagedResult<Kanjidic2ExtensionModel>();
        pagedResult.PageSize = pagination.PageSize;
        pagination.Page = pagination.Page;

        pagedResult.Items = await Collection.AsQueryable()
            .Where(x => x.JlptLevel == jlptLevel)
            .Skip((pagination.Page - 1) * pagination.PageSize).Take(pagination.PageSize).ToListAsync();

        pagedResult.TotalItems = await Collection.AsQueryable()
            .CountAsync(x => x.JlptLevel == jlptLevel);

        return pagedResult;
    }

    public async Task<PagedResult<Kanjidic2ExtensionModel>> GetKanjiByKankenAsync(Pagination pagination)
    {
        int kankenLevel = 0;
        if (!int.TryParse(pagination.FilterValue, out kankenLevel))
            throw new Exception("");

        PagedResult<Kanjidic2ExtensionModel> pagedResult = new PagedResult<Kanjidic2ExtensionModel>();
        pagedResult.PageSize = pagination.PageSize;
        pagination.Page = pagination.Page;

        pagedResult.Items = await Collection.AsQueryable()
            .Where(x => x.KankenLevel == kankenLevel)
            .Skip((pagination.Page - 1) * pagination.PageSize).Take(pagination.PageSize).ToListAsync();

        pagedResult.TotalItems = await Collection.AsQueryable()
            .CountAsync(x => x.KankenLevel == kankenLevel);

        return pagedResult;
    }
}