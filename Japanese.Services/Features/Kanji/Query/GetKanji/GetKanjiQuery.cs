using Japanese.Services.Cache;
using MediatR;
using Newtonsoft.Json;

namespace Japanese.Services.Features.Kanji.Queries.GetKanji;

public class GetKanjiQuery : IRequest<KanjiDetailOutput>, ICacheableQuery
{
    public string? Kanji { get; set; }

    public string? CacheKey => $"kanji_{Kanji}";

    public bool Bypass { get; set; }
    public bool RefreshCache { get; set; }
}