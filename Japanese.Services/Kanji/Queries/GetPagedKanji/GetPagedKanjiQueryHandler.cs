using Japanese.Core.CommonModels;
using Japanese.Core.Encoding;
using Japanese.Models;
using Japanese.Repositories.Interfaces;
using Japanese.Services.Kanji.Queries.GetKanji;
using MediatR;

namespace Japanese.Services.Kanji.Queries.GetPagedKanji;

public class GetPagedKanjiQueryHandler : IRequestHandler<GetPagedKanjiQuery, Pagination<KanjiDetailOutput>>
{
    private readonly IKanjiRepository _kanjiRepository;

    public GetPagedKanjiQueryHandler(IJapaneseRepository japaneseRepository)
    {
        _kanjiRepository = japaneseRepository.KanjiRepository;
    }

    public async Task<Pagination<KanjiDetailOutput>> Handle(GetPagedKanjiQuery request, CancellationToken cancellationToken)
    {
        Base64 base64 = new Base64();
        request.PaginationToken = base64.Decode(request.PaginationToken);
        Pagination<KanjiModel> paged = await _kanjiRepository.GetPagedAsync(request);

        return new Pagination<KanjiDetailOutput>
        {
            PaginationToken = base64.Encode(paged.PaginationToken),
            PageSize = paged.PageSize,
            Items = paged.Items.Select(kanjiModel => new KanjiDetailOutput
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
