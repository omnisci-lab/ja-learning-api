using Japanese.Services.Cache;
using MediatR;

namespace Japanese.Services.Features.Sentence.Query.GetSentence;

public class GetSentenceQuery : IRequest<SentenceOutput>, ICacheableQuery
{
    public string? SentenceId { get; set; }

    public string? CacheKey => $"sentence_id_{SentenceId}";

    public bool Bypass { get; set; }
    public bool RefreshCache { get; set; }
}