using Japanese.Core.CommonModels;
using Japanese.Core.Enum;
using Japanese.Models;
using Japanese.Repositories.Interfaces;
using Japanese.Services.Kanji.Queries.GetKanji;
using MediatR;

namespace Japanese.Services.Kanji.Queries.GetKanjiListByJlpt;

public class GetKanjiListByJlptQueryHandler : IRequestHandler<GetKanjiListByJlptQuery, ExecResult<List<KanjiDetailOutput>>>
{
    private readonly IKanjiRepository _kanjiRepository;

    public GetKanjiListByJlptQueryHandler(IJapaneseRepository repository)
    {
        _kanjiRepository = repository.KanjiRepository;
    }

    public async Task<ExecResult<List<KanjiDetailOutput>>> Handle(GetKanjiListByJlptQuery request, CancellationToken cancellationToken)
    {
        List<KanjiModel> kanjiModels = await _kanjiRepository.GetListByJlptAsync(request.JlptLevel);

        return new ExecResult<List<KanjiDetailOutput>>
        {
            Status = ExecStatus.Success,
            Data = kanjiModels.Select(kanjiModel => new KanjiDetailOutput
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
            }).ToList()
        };
    }
}
