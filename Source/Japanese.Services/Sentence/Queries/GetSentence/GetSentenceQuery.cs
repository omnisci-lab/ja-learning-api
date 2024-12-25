using Japanese.Core.CommonModels;
using Japanese.Services.Cache;
using MediatR;

namespace Japanese.Services.Sentence.Queries.GetSentence;

public class GetSentenceQuery : IRequest<ExecResult<SentenceOutput?>>, ICacheableQuery
{
    public string? SentenceId { get; set; }

    public string? CacheKey => $"sentence_id_{SentenceId}";

    public bool BypassCache { get; set; }
    public bool RefreshCache { get; set; }
}