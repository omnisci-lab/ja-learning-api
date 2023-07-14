using Japanese.Core.CommonModels;
using Japanese.Core.RepositoryBase;
using Japanese.Models;

namespace Japanese.Repositories.Interfaces;

public interface ISentenceRepository : IAsyncRepository<SentenceModel>
{
    Task<PagedResult<SentenceModel>> SearchByTextAsync(Pagination pagination);
    Task<PagedResult<SentenceModel>> SearchByViMeaningAsync(Pagination pagination);
}