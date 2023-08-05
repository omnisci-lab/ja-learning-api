using Japanese.Core.CommonModels;
using Japanese.LanguageCore.Repositories;
using Japanese.Models;

namespace Japanese.Repositories.Interfaces;

public interface IJlptKanjiRepository : IAppRepository<JlptKanjiModel>
{
    Task<PagedResult<JlptKanjiModel>> GetJlptKanjiAsync(Pagination pagination);
}
