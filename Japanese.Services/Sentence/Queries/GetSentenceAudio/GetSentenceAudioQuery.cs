using Japanese.Core.CommonModels;
using Japanese.LanguageCore.Enum;
using Japanese.Services.Cache;
using MediatR;

namespace Japanese.Services.Sentence.Queries.GetSentenceAudio;

public class GetSentenceAudioQuery : IRequest<ExecResult<byte[]>>, ICacheableQuery
{
    public string? SentenceId { get; set; }
    public VoiceOptions VoiceOptions { get; set; }

    public string? CacheKey => $"sentence_id_{SentenceId}_{VoiceOptions}";

    public bool Bypass { get; set; }
    public bool RefreshCache { get; set; }
}
