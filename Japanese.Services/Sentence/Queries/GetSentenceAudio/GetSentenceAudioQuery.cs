using Japanese.Core.CommonModels;
using Japanese.Services.Cache;
using MediatR;

namespace Japanese.Services.Sentence.Queries.GetSentenceAudio;

public class GetSentenceAudioQuery : IRequest<ExecResult<byte[]>>, ICacheableQuery
{
    public string? SentenceId { get; set; }

    public string? CacheKey => $"sentence_id_{SentenceId}";

    public bool Bypass { get; set; }
    public bool RefreshCache { get; set; }
}
