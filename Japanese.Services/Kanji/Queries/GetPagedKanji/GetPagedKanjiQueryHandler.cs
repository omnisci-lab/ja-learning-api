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
    private readonly IKanjidic2Repository _kanjidic2Repository;
    private readonly IJlptKanjiRepository _jlptKanjiRepository;
    private readonly IKankenRepository _kankenRepository;
    private readonly IKanjidic2ExtensionRepository _kanjidic2ExtensionRepository;
    private readonly IMapper _mapper;
    private Base64 _base64;

    public GetPagedKanjiQueryHandler(IJapaneseRepository repository, IMapper mapper)
    {
        _kanjidic2Repository = repository.Kanjidic2Repository;
        _kanjidic2ExtensionRepository = repository.Kanjidic2ExtensionRepository;
        _jlptKanjiRepository = repository.JlptKanjiRepository;
        _kankenRepository = repository.KankenRepository;
        _mapper = mapper;
        _base64 = new Base64();
    }

    public async Task<ExecResult<PagedResult<KanjiDetailOutput>>> Handle(GetPagedKanjiQuery request, CancellationToken cancellationToken)
    {
        if (!string.IsNullOrEmpty(request.PaginationToken))
            request.PaginationToken = _base64.Decode(request.PaginationToken);

        PagedResult<KanjiDetailOutput>? paged = new PagedResult<KanjiDetailOutput>();
        List<string>? literalIdList = null;

        if (request.SearchBy == SearchKanjiConsts.ByJLpt)
        {
            PagedResult<JlptKanjiModel> pagedJlptKanji = await _jlptKanjiRepository.GetJlptKanjiAsync(request);
            literalIdList = pagedJlptKanji.Items.Select(s => s.Kanji).ToList()!;

            paged = _mapper.Map<PagedResult<JlptKanjiModel>, PagedResult<KanjiDetailOutput>>(pagedJlptKanji);
        }
        else if (request.SearchBy == SearchKanjiConsts.ByKanken)
        {
            PagedResult<KankenModel> pagedKanken = await _kankenRepository.GetKanjiByKankenLevel(request);
            literalIdList = pagedKanken.Items.Select(s => s.Kanji).ToList()!;

            paged = _mapper.Map<PagedResult<KankenModel>, PagedResult<KanjiDetailOutput>>(pagedKanken);
        }
        else
        {
            throw new Exception();
        }

        List<Kanjidic2Model>? kanjidic2Models = await _kanjidic2Repository.GetItemsByLiteralsAsync(literalIdList);
        List<Kanjidic2ExtensionModel>? kanjidic2ExtensionModels = await _kanjidic2ExtensionRepository
            .GetItemsByLiteralsAsync(literalIdList);

        List<Kanjidic2ExtensionModel> newKanjidic2ExtensionModels = new List<Kanjidic2ExtensionModel>();
        foreach(Kanjidic2Model kanjidic2Model in kanjidic2Models)
        {
            Kanjidic2ExtensionModel? additionalKanji = kanjidic2ExtensionModels
                .SingleOrDefault(x => x.Literal == kanjidic2Model.Literal);

            if (additionalKanji is null)
                newKanjidic2ExtensionModels.Add(_mapper.Map<Kanjidic2Model, Kanjidic2ExtensionModel>(kanjidic2Model));
            else
                newKanjidic2ExtensionModels.Add(_mapper.Map(kanjidic2Model, additionalKanji));
        }

        paged.Items = _mapper.Map<List<Kanjidic2ExtensionModel>, List<KanjiDetailOutput>>(newKanjidic2ExtensionModels);

        if (!string.IsNullOrEmpty(paged.PaginationToken))
            paged.PaginationToken = _base64.Encode(paged.PaginationToken);

        return new ExecResult<PagedResult<KanjiDetailOutput>>
        {
            Status = ExecStatus.Success,
            Data = paged
        };
    }
}