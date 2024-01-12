using Japanese.Core.CommonModels;
using Japanese.Services.Cache;
using MediatR;

namespace Japanese.Services.Kanji.Queries.GetPagedKanji;

public class GetPagedKanjiQuery : Pagination, IRequest<ExecResult<PagedResult<KanjiDetailOutput>>>, ICacheableQuery
{
    public string? CacheKey => $"kanjilist_p{Page}_pz{PageSize}";

    public bool BypassCache { get; set; }
    public bool RefreshCache { get; set; }
}