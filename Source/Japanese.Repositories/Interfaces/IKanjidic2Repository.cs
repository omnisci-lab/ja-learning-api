using Japanese.Core.CommonModels;
using Japanese.Core.RepositoryBase.MongoDB;
using Japanese.Models;
using static Japanese.Models.Kanjidic2Model;

namespace Japanese.Repositories.Interfaces;

public interface IKanjidic2Repository : IAppRepository<Kanjidic2Model>
{
    Task<PagedResult<Kanjidic2Model>> GetKanjiByJlptAsync(Pagination pagination);
    Task<PagedResult<Kanjidic2Model>> GetKanjiByKankenAsync(Pagination pagination);
    Task<Kanjidic2Model> GetByLiteralAsync(string literal);
    Task<List<Kanjidic2Model>> GetItemsByLiteralsAsync(List<string?> literals);
    Task<List<Kanjidic2Model>> GetVarirantsAsync(List<CodepointModel> codepoints);
}