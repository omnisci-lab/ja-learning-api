using khothemegiatot.WebApi.CQRS.Cache;
using khothemegiatot.WebApi.Models;
using MediatR;

namespace Japanese.Services.CommonWord.Queries.GetPagedCommonWords;

public class GetPagedCommonWordsQuery : Pagination, IRequest<ExecResult<PagedResult<CommonWordOutput>>>, ICacheableQuery
{
    public string? CacheKey => $"sentences_ps_{PageSize}_ptk__fb_{FilterBy}_fv_{FilterValue}_k_{Keyword}";

    public bool BypassCache { get; set; }
    public bool RefreshCache { get; set; }
}
