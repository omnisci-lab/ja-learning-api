using Japanese.Core.CommonModels;
using Japanese.Core.Enum;
using Japanese.Services.Cache;
using MediatR;

namespace Japanese.Services.Sentence.Queries.GetSentenceAudio;

public class GetSentenceAudioQuery : IRequest<FileResult>, ICacheableQuery
{
    public string? SentenceId { get; set; }
    public VoiceOptions VoiceOptions { get; set; }

    public string? CacheKey => $"sentence_id_{SentenceId}_{VoiceOptions}";

    public bool BypassCache { get; set; }
    public bool RefreshCache { get; set; }
}