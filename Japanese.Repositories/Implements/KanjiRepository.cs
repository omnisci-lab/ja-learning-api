using Japanese.Core.CommonModels;
using Japanese.Core.RepositoryBase.MongoDB;
using Japanese.Models;
using Japanese.Repositories.Interfaces;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using static MongoDB.Driver.WriteConcern;

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
            .Where(x => x.Character == literal).SingleOrDefaultAsync();
    }

    public async Task<PagedResult<KanjiModel>> GetKanjiByJlptAsync(Pagination pagination)
    {
        int jlptLevel = 0;
        if (!int.TryParse(pagination.FilterValue, out jlptLevel))
            throw new Exception("");

        PagedResult<KanjiModel> pagedResult = new PagedResult<KanjiModel>();
        pagedResult.PageSize = pagination.PageSize;
        pagination.Page = pagination.Page;

        pagedResult.Items = await Collection.AsQueryable()
            .Where(x => x.Level != null && x.Level.Jlpt != null)
            .Where(x => x.Level!.Jlpt == jlptLevel)
            .Skip((pagination.Page - 1) * pagination.PageSize).Take(pagination.PageSize).ToListAsync();

        pagedResult.TotalItems = await Collection.AsQueryable()
            .CountAsync(x => x.Level!.Jlpt == jlptLevel);

        return pagedResult;
    }

    public async Task<PagedResult<KanjiModel>> GetKanjiByKankenAsync(Pagination pagination)
    {
        int kankenLevel = 0;
        if (!int.TryParse(pagination.FilterValue, out kankenLevel))
            throw new Exception("");

        PagedResult<KanjiModel> pagedResult = new PagedResult<KanjiModel>();
        pagedResult.PageSize = pagination.PageSize;
        pagination.Page = pagination.Page;

        pagedResult.Items = await Collection.AsQueryable()
            .Where(x => x.Level != null && x.Level.Kanken != null)
            .Where(x => x.Level!.Kanken == kankenLevel)
            .Skip((pagination.Page - 1) * pagination.PageSize).Take(pagination.PageSize).ToListAsync();

        pagedResult.TotalItems = await Collection.AsQueryable()
            .CountAsync(x => x.Level!.Kanken == kankenLevel);

        return pagedResult;
    }

    public async Task UpdateAsync(KanjiModel kanjiModel)
    {
        Dictionary<string, object> update = new Dictionary<string, object>();
        update.Add("strokeCount", kanjiModel.StrokeCount);

        await UpdateAsync(f => f.Character, kanjiModel.Character, update);
    }
}
