using Japanese.Core.CommonModels;
using Japanese.Models;

namespace Japanese.CachedRepository.Interfaces;

public interface IKanjidic2CachedRepository
{
    Task<PagedResult<Kanjidic2Model>> GetPaginatedAsync(Pagination pagination);
}