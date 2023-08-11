using Japanese.LanguageCore.Repositories;
using Japanese.Models;

namespace Japanese.Repositories.Interfaces;

public interface IAdditionalKanjiRepository : IAppRepository<AdditionalKanjiModel>
{
    Task<List<AdditionalKanjiModel>> GetItemsByIdsAsync(List<string> keys);
}
