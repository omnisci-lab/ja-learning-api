using Japanese.Core.CommonModels;
using Japanese.Services.Cache;
using MediatR;

namespace Japanese.Services.Kanji.Queries.GetPagedKanji;

public class GetPagedKanjiQuery : Pagination, IRequest<ExecResult<PagedResult<KanjiDetailOutput>>>, ICacheableQuery
{
    public string? CacheKey => $"kanji_ps_{PageSize}_ptk_{PaginationToken}_fb_{FilterBy}_fv_{FilterValue}_k_{Keyword}";

    public bool BypassCache { get; set; }
    public bool RefreshCache { get; set; }
}