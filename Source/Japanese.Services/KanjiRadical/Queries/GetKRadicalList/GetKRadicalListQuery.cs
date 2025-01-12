using khothemegiatot.WebApi.CQRS.Cache;
using khothemegiatot.WebApi.Models;
using MediatR;

namespace Japanese.Services.KanjiRadical.Queries.GetKRadicalList;

public class GetKRadicalListQuery : IRequest<ExecResult<List<KRadicalDetailOutput>>>, ICacheableQuery
{
    public string? CacheKey => "kradicallist_t:{KanaType}";

    public bool BypassCache { get; set; }
    public bool RefreshCache { get; set; }
}
