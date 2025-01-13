using Japanese.Models;
using khothemegiatot.WebApi.Repositories.MongoDB;

namespace Japanese.Repositories.Interfaces;

public interface IKanjiRadicalRepository : IAppRepository<KanjiRadicalModel>
{
    Task<KanjiRadicalModel> GetByCharacterAsync(string character);
}