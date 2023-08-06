using Japanese.Core.CommonModels;
using Japanese.LanguageCore.Repositories;
using Japanese.Models;

namespace Japanese.Repositories.Interfaces;

public interface IKankenRepository : IAppRepository<KankenModel>
{
    Task<PagedResult<KankenModel>> GetKanjiByKankenLevel(Pagination pagination);
}