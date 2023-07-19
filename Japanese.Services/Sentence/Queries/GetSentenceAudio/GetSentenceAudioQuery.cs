using Japanese.Core.CommonModels;
using Japanese.Services.Cache;
using MediatR;

namespace Japanese.Services.Sentence.Queries.GetSentenceAudio;

public class GetSentenceAudioQuery : IRequest<ExecResult<MemoryStream>>, ICacheableQuery
{
    public string? SentenceId { get; set; }

    public string? CacheKey => "";

    public bool Bypass { get; set; }
    public bool RefreshCache { get; set; }
}
