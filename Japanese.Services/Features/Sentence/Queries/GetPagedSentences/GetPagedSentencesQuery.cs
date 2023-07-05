using Japanese.Core.CommonModels;
using Japanese.Services.Cache;
using MediatR;

namespace Japanese.Services.Features.Sentence.Queries.GetPagedSentences;

public class GetPagedSentencesQuery : Pagination, IRequest<ExecResult<Pagination<SentenceOutput>>>, ICacheableQuery
{
    public string? CacheKey => $"get_sentences_token";

    public bool Bypass { get; set; }
    public bool RefreshCache { get; set; }
}