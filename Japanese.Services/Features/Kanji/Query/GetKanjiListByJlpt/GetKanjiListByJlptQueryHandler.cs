using Japanese.Models;
using Japanese.Repositories.Interfaces;
using Japanese.Services.Features.Kanji.Queries.GetKanji;
using MediatR;

namespace Japanese.Services.Features.Kanji.Query.GetKanjiListByJlpt;

public class GetKanjiListByJlptQueryHandler : IRequestHandler<GetKanjiListByJlptQuery, List<KanjiDetailOutput>>
{
    private readonly IKanjiRepository _kanjiRepository;

    public GetKanjiListByJlptQueryHandler(IJapaneseRepository repository)
    {
        _kanjiRepository = repository.KanjiRepository;
    }

    public async Task<List<KanjiDetailOutput>> Handle(GetKanjiListByJlptQuery request, CancellationToken cancellationToken)
    {
        List<KanjiModel> kanjiModels = await _kanjiRepository.GetListByJlptAsync(request.JlptLevel);

        return kanjiModels.Select(kanjiModel => new KanjiDetailOutput
        {
            Kanji = kanjiModel.Kanji,
            StrokeCount = kanjiModel.StrokeCount,
            Grade = kanjiModel.Grade,
            OnReadings = kanjiModel.OnReadings,
            KunReadings = kanjiModel.KunReadings,
            NameReadings = kanjiModel.NameReadings,
            Meanings = kanjiModel.Meanings,
            Jlpt = kanjiModel.Jlpt,
            Unicode = kanjiModel.Unicode
        }).ToList();
    }
}
