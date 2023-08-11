using Japanese.LanguageCore.Repositories;
using Japanese.Models;

namespace Japanese.Repositories.Interfaces;

public interface IKanjidic2Repository : IAppRepository<Kanjidic2Model>
{
    Task<List<Kanjidic2Model>> GetItemsByIdsAsync(List<string> keys);
}
