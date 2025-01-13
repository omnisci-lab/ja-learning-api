using khothemegiatot.WebApi.CQRS.Cache;
using khothemegiatot.WebApi.Models;
using MediatR;

namespace Japanese.Services.Kanji.Queries.GetPagedKanji;

public class GetPagedKanjiQuery : Pagination, IRequest<ExecResult<PagedResult<KanjiDetailOutput>>>, ICacheableQuery
{
    public bool FromKanjidic2 { get; set; }
    public string? CacheKey => $"kanjilist_p:{Page}_pz:{PageSize}";

    public bool BypassCache { get; set; }
    public bool RefreshCache { get; set; }
}