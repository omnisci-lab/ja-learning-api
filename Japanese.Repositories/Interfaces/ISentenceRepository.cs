using Japanese.Core.RepositoryBase;
using Japanese.Models;

namespace Japanese.Repositories.Interfaces;

public interface ISentenceRepository : IAsyncRepository<SentenceModel>
{
    Task<List<SentenceModel>> SearchAsync(string searchBy, string keyword);
}