using Japanese.Core.RepositoryBase.MongoDB;
using Japanese.Models;

namespace Japanese.Repositories.Interfaces;

public interface IKanjiRepository : IAppRepository<KanjiModel>
{
    Task<KanjiModel> GetByLiteralAsync(string literal);
}
