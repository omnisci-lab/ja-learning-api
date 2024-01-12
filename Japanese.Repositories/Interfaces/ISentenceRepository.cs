using Japanese.Core.CommonModels;
using Japanese.Core.RepositoryBase.MongoDB;
using Japanese.Models;

namespace Japanese.Repositories.Interfaces;

public interface ISentenceRepository : IAppRepository<SentenceModel>
{
    Task<PagedResult<SentenceModel>> SearchByTextAsync(Pagination pagination);
    Task<PagedResult<SentenceModel>> SearchByViMeaningAsync(Pagination pagination);
}