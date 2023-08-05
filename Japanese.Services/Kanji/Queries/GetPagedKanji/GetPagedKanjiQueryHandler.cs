using AutoMapper;
using Japanese.Core.CommonModels;
using Japanese.Core.Encoding;
using Japanese.Core.Enum;
using Japanese.Models;
using Japanese.Repositories.Interfaces;
using Japanese.Services.Kanji.Consts;
using MediatR;

namespace Japanese.Services.Kanji.Queries.GetPagedKanji;

public class GetPagedKanjiQueryHandler : IRequestHandler<GetPagedKanjiQuery, ExecResult<PagedResult<KanjiDetailOutput>>>
{
    private readonly IKanjiRepository _kanjiRepository;
    private readonly IKanjidic2Repository _kanjidic2Repository;
    private readonly IJlptKanjiRepository _jlptKanjiRepository;
    private readonly IMapper _mapper;
    private Base64 _base64;

    public GetPagedKanjiQueryHandler(IJapaneseRepository japaneseRepository, IMapper mapper)
    {
        _kanjiRepository = japaneseRepository.KanjiRepository;
        _kanjidic2Repository = japaneseRepository.Kanjidic2Repository;
        _jlptKanjiRepository = japaneseRepository.JlptKanjiRepository;
        _mapper = mapper;
        _base64 = new Base64();
    }

    public async Task<ExecResult<PagedResult<KanjiDetailOutput>>> Handle(GetPagedKanjiQuery request, CancellationToken cancellationToken)
    {
        if (!string.IsNullOrEmpty(request.PaginationToken))
            request.PaginationToken = _base64.Decode(request.PaginationToken);

        PagedResult<KanjiModel>? paged_raw = null;

        if (string.IsNullOrEmpty(request.Keyword))
            paged_raw = await _kanjiRepository.GetPagedAsync(request);
        else if (request.SearchBy == SearchKanjiConsts.ByOnReadings)
            paged_raw = await _kanjiRepository.SearchByOnReadingAsync(request);
        else if (request.SearchBy == SearchKanjiConsts.ByKunReadings)
            paged_raw = await _kanjiRepository.SearchByKunReadingAsync(request);
        else if (request.SearchBy == SearchKanjiConsts.ByNameReadings)
            paged_raw = await _kanjiRepository.SearchByNameReadingAsync(request);
        else if (request.SearchBy == SearchKanjiConsts.ByJLpt)
        {
            PagedResult<JlptKanjiModel> pagedJlptKanji = await _jlptKanjiRepository.GetJlptKanjiAsync(request);
            List<string> ids = pagedJlptKanji.Items.Select(s => s.Kanji).ToList()!;

            List<Kanjidic2Model> kanjidic2Models = await _kanjidic2Repository.GetItemsByIdsAsync(ids);
            List<KanjiDetailOutput> kanjiDetails = new List<KanjiDetailOutput>();

            foreach(Kanjidic2Model kanjidic2Model in kanjidic2Models)
            {
                kanjiDetails.Add(_mapper.Map<Kanjidic2Model, KanjiDetailOutput>(kanjidic2Model));
            }

            //PagedResult<KanjiDetailOutput> paged1 = _mapper.Map<PagedResult<JlptKanjiModel>, PagedResult<KanjiDetailOutput>>(pagedJlptKanji);
            PagedResult<KanjiDetailOutput> paged1 = new PagedResult<KanjiDetailOutput>
            {
                Keyword = pagedJlptKanji.Keyword,
                SearchBy = pagedJlptKanji.SearchBy,
                PaginationToken = pagedJlptKanji.PaginationToken,
                PageSize = pagedJlptKanji.PageSize,
                Items = kanjiDetails
            };

            return new ExecResult<PagedResult<KanjiDetailOutput>>
            {
                Status = ExecStatus.Success, Data = paged1
            };

            //paged_raw = await _kanjiRepository.SearchByJlptAsync(request);
        }
        else if (request.SearchBy == SearchKanjiConsts.ByStrokeCount)
            paged_raw = await _kanjiRepository.SearchByStrokeCountAsync(request);
        else if (request.SearchBy == SearchKanjiConsts.ByEnMeanings)
            paged_raw = await _kanjiRepository.SearchByEnMeaningAsync(request);
        else if (request.SearchBy == SearchKanjiConsts.ByViMeanings)
            paged_raw = await _kanjiRepository.SearchByViMeaningAsync(request);
        else if (request.SearchBy == SearchKanjiConsts.BySinoVietnamese)
            paged_raw = await _kanjiRepository.SearchBySinoVietnameseAsync(request);
        else
            paged_raw = await _kanjiRepository.GetPagedAsync(request);

        PagedResult<KanjiDetailOutput> paged = _mapper.Map<PagedResult<KanjiModel>, PagedResult<KanjiDetailOutput>>(paged_raw);
        if (!string.IsNullOrEmpty(paged.PaginationToken))
            paged.PaginationToken = _base64.Encode(paged.PaginationToken);

        return new ExecResult<PagedResult<KanjiDetailOutput>>
        {
            Status = ExecStatus.Success,
            Data = paged
        };
    }
}