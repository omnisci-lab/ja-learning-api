using Japanese.Core.CommonModels;
using Japanese.Core.RepositoryBase.MongoDB;
using Japanese.Models;
using Japanese.Repositories.Interfaces;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace Japanese.Repositories.Implements;

public class Kanjidic2Repository : AppRepository<Kanjidic2Model>, IKanjidic2Repository
{
    public Kanjidic2Repository(IMongoDatabase database, string collectionName)
        : base(database, collectionName)
    {
    }

    public async Task<Kanjidic2Model> GetByLiteralAsync(string literal)
    {
        return await Collection.AsQueryable()
            .Where(x => x.Literal == literal).SingleOrDefaultAsync();
    }

    public async Task<List<Kanjidic2Model>> GetItemsByLiteralsAsync(List<string?> literals)
    {
        return await Collection.AsQueryable().Where(x => literals.Contains(x.Literal)).ToListAsync();
    }

    public async Task<PagedResult<Kanjidic2Model>> GetKanjiByJlptAsync(Pagination pagination)
    {
        int jlptLevel = 0;
        if (!int.TryParse(pagination.FilterValue, out jlptLevel))
            throw new Exception("");

        PagedResult<Kanjidic2Model> pagedResult = new PagedResult<Kanjidic2Model>();
        pagedResult.PageSize = pagination.PageSize;
        pagination.Page = pagination.Page;

        pagedResult.Items = await Collection.AsQueryable()
            .Where(x => x.Misc != null && x.Misc.JlptLevel == jlptLevel)
            .Skip((pagination.Page - 1) * pagination.PageSize).Take(pagination.PageSize).ToListAsync();

        pagedResult.TotalItems = await Collection.AsQueryable()
            .CountAsync(x => x.Misc != null && x.Misc.JlptLevel == jlptLevel);

        return pagedResult;
    }

    public async Task<PagedResult<Kanjidic2Model>> GetKanjiByKankenAsync(Pagination pagination)
    {
        int jlptLevel = 0;
        if (!int.TryParse(pagination.FilterValue, out jlptLevel))
            throw new Exception("");

        PagedResult<Kanjidic2Model> pagedResult = new PagedResult<Kanjidic2Model>();
        pagedResult.PageSize = pagination.PageSize;
        pagination.Page = pagination.Page;

        pagedResult.Items = await Collection.AsQueryable()
            .Where(x => x.Misc != null && x.Misc.JlptLevel == jlptLevel)
            .Skip((pagination.Page - 1) * pagination.PageSize).Take(pagination.PageSize).ToListAsync();

        pagedResult.TotalItems = await Collection.AsQueryable()
            .CountAsync(x => x.Misc != null && x.Misc.JlptLevel == jlptLevel);

        return pagedResult;
    }
}