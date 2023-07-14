using Japanese.Core.CommonModels;
using Japanese.Services.Cache;
using MediatR;

namespace Japanese.Services.Sentence.Queries.GetPagedSentences;

public class GetPagedSentencesQuery : Pagination, IRequest<ExecResult<PagedResult<SentenceOutput>>>, ICacheableQuery
{
    public string? CacheKey => $"get_sentences_pagesize";

    public bool Bypass { get; set; }
    public bool RefreshCache { get; set; }
}