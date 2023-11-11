using Japanese.Core.CommonModels;
using Japanese.Services.Cache;
using MediatR;

namespace Japanese.Services.Sentence.Queries.GetPagedSentences;

public class GetPagedSentencesQuery : Pagination, IRequest<ExecResult<PagedResult<SentenceOutput>>>, ICacheableQuery
{
    public string? CacheKey => $"sentences_ps_{PageSize}_ptk_{PaginationToken}_fb_{FilterBy}_fv_{FilterValue}_k_{Keyword}";

    public bool BypassCache { get; set; }
    public bool RefreshCache { get; set; }
}