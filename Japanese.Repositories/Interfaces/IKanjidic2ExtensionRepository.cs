using Japanese.Core.RepositoryBase;
using Japanese.Models;

namespace Japanese.Repositories.Interfaces;

public interface IKanjidic2ExtensionRepository : IAppRepository<Kanjidic2ExtensionModel>
{
    Task<List<Kanjidic2ExtensionModel>> GetItemsByLiteralsAsync(List<string> keys);
}
