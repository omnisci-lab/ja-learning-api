using Japanese.Core.CommonModels;
using Japanese.Services.Cache;
using Japanese.Services.Kanji.Queries.GetKanji;
using MediatR;

namespace Japanese.Services.Kanji.Queries.GetKanjiListByJlpt;

public class GetKanjiListByJlptQuery : IRequest<ExecResult<List<KanjiDetailOutput>>>, ICacheableQuery
{
    public int? JlptLevel { get; set; }

    public string? CacheKey => $"kanji_list_by_jlpt_{JlptLevel}";

    public bool Bypass { get; set; }
    public bool RefreshCache { get; set; }
}