using Japanese.Models;
using Japanese.Repositories.Interfaces;
using MediatR;

namespace Japanese.Services.Features.Kanji.Queries.GetKanji;

public class GetKanjiQueryHandler : IRequestHandler<GetKanjiQuery, KanjiDetailOutput?>
{
    private readonly IKanjiRepository _kanjiRepository;

    public GetKanjiQueryHandler(IJapaneseRepository repository)
    {
        _kanjiRepository = repository.KanjiRepository;
    }

    public async Task<KanjiDetailOutput?> Handle(GetKanjiQuery request, CancellationToken cancellationToken)
    {
        KanjiModel? kanjiModel = await _kanjiRepository.GetAsync(request.Kanji);
        if (kanjiModel is null)
            return null;

        return new KanjiDetailOutput
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
        };
    }
}
