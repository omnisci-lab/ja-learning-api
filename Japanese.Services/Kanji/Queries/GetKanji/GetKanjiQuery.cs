using Japanese.Core.CommonModels;
using Japanese.Services.Cache;
using MediatR;
using Newtonsoft.Json;

namespace Japanese.Services.Kanji.Queries.GetKanji;

public class GetKanjiQuery : IRequest<ExecResult<KanjiDetailOutput?>>, ICacheableQuery
{
    public string? Kanji { get; set; }

    public string? CacheKey => $"kanji_{Kanji}";

    public bool Bypass { get; set; }
    public bool RefreshCache { get; set; }
}