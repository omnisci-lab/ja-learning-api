using Japanese.Models;
using khothemegiatot.WebApi.Repositories.MongoDB;

namespace Japanese.Repositories.Interfaces;

public interface IKanjiComponentRepository : IAppRepository<KanjiComponentModel>
{
    Task<KanjiComponentModel> GetByLiteralAsync(string literal);
}
