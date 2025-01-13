using Japanese.Models;
using khothemegiatot.WebApi.Models;
using khothemegiatot.WebApi.Repositories.MongoDB;

namespace Japanese.Repositories.Interfaces;

public interface IKanjiRepository : IAppRepository<KanjiModel>
{
    Task<KanjiModel> GetByLiteralAsync(string literal);
    Task<PagedResult<KanjiModel>> GetKanjiByJlptAsync(Pagination pagination);
    Task<PagedResult<KanjiModel>> GetKanjiByKankenAsync(Pagination pagination);
    Task UpdateAsync(KanjiModel kanjiModel);
}