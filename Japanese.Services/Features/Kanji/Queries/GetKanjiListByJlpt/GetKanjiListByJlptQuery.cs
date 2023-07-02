using Japanese.Services.Cache;
using Japanese.Services.Features.Kanji.Queries.GetKanji;
using MediatR;

namespace Japanese.Services.Features.Kanji.Queries.GetKanjiListByJlpt;

public class GetKanjiListByJlptQuery : IRequest<List<KanjiDetailOutput>>, ICacheableQuery
{
    public int? JlptLevel { get; set; }

    public string? CacheKey => $"kanji_list_by_jlpt_{JlptLevel}";

    public bool Bypass { get; set; }
    public bool RefreshCache { get; set; }
}