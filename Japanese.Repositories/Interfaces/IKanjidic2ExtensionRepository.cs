using Japanese.Core.CommonModels;
using Japanese.Core.RepositoryBase.MongoDB;
using Japanese.Models;

namespace Japanese.Repositories.Interfaces;

public interface IKanjidic2ExtensionRepository : IAppRepository<Kanjidic2ExtensionModel>
{
    Task<Kanjidic2ExtensionModel> GetByLiteralAsync(string literal);
    Task<List<Kanjidic2ExtensionModel>> GetItemsByLiteralsAsync(List<string?> literals);
    Task<PagedResult<Kanjidic2ExtensionModel>> GetKanjiByJlptAsync(Pagination pagination);
    Task<PagedResult<Kanjidic2ExtensionModel>> GetKanjiByKankenAsync(Pagination pagination);
}