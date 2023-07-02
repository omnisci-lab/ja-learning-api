using Japanese.Core.CommonModels;
using Japanese.Models;
using Japanese.Repositories.Interfaces;
using Japanese.Services.Features.Kanji.Queries.GetKanji;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Japanese.Services.Features.Kanji.Query.GetPagedKanji;

public class GetPagedKanjiQueryHandler : IRequestHandler<GetPagedKanjiQuery, Pagination<KanjiDetailOutput>>
{
    private readonly IKanjiRepository _kanjiRepository;

    public GetPagedKanjiQueryHandler(IJapaneseRepository japaneseRepository)
    {
        _kanjiRepository = japaneseRepository.KanjiRepository;
    }

    public async Task<Pagination<KanjiDetailOutput>> Handle(GetPagedKanjiQuery request, CancellationToken cancellationToken)
    {
        Pagination<KanjiModel> paged = await _kanjiRepository.GetPagedAsync(request);

        return new Pagination<KanjiDetailOutput>
        {
            PaginationToken = paged.PaginationToken,
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
