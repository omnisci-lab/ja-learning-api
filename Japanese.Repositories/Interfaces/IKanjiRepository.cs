using Japanese.Core.RepositoryBase;
using Japanese.Models;

namespace Japanese.Repositories.Interfaces;

public interface IKanjiRepository : IAsyncRepository<KanjiModel>
{
    Task<List<KanjiModel>> GetListByJlptAsync(int? jlpt);
}
