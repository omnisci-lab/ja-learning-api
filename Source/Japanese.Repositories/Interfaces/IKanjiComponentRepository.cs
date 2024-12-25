using Japanese.Core.RepositoryBase.MongoDB;
using Japanese.Models;

namespace Japanese.Repositories.Interfaces;

public interface IKanjiComponentRepository : IAppRepository<KanjiComponentModel>
{
    Task<KanjiComponentModel> GetByLiteralAsync(string literal);
}
