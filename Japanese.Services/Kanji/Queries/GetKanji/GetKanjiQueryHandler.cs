using AutoMapper;
using Japanese.Core.CommonModels;
using Japanese.Core.Enum;
using Japanese.Models;
using Japanese.Repositories.Interfaces;
using MediatR;

namespace Japanese.Services.Kanji.Queries.GetKanji;

public class GetKanjiQueryHandler : IRequestHandler<GetKanjiQuery, ExecResult<KanjiDetailOutput?>>
{
    private readonly IKanjidic2Repository _kanjidic2Repository;
    private readonly IKanjiComponentRepository _kanjiComponentRepository;
    private readonly IAdditionalKanjiRepository _additionalKanjiRepository;
    private readonly IMapper _mapper;

    public GetKanjiQueryHandler(IJapaneseRepository repository, IMapper mapper)
    {
        _kanjidic2Repository = repository.Kanjidic2Repository;
        _kanjiComponentRepository = repository.KanjiComponentRepository;
        _additionalKanjiRepository = repository.AdditionalKanjiRepository;
        _mapper = mapper;
    }

    public async Task<ExecResult<KanjiDetailOutput?>> Handle(GetKanjiQuery request, CancellationToken cancellationToken)
    {
        Kanjidic2Model? kanjidic2Model = await _kanjidic2Repository.GetAsync(request.Kanji);
        AdditionalKanjiModel? additionalKanjiModel = await _additionalKanjiRepository.GetAsync(request.Kanji);
        if (additionalKanjiModel is not null)
            _ = _mapper.Map(additionalKanjiModel, kanjidic2Model);

        if (kanjidic2Model is null && additionalKanjiModel is null)
            return new ExecResult<KanjiDetailOutput?> { Status = ExecStatus.NotFound };

        if (kanjidic2Model is not null && additionalKanjiModel is not null)
            _ = _mapper.Map(kanjidic2Model, additionalKanjiModel);
        
        if (kanjidic2Model is not null && additionalKanjiModel is null)
            additionalKanjiModel = _mapper.Map<Kanjidic2Model, AdditionalKanjiModel>(kanjidic2Model);

        KanjiDetailOutput? kanjiDetail = null;
        if (additionalKanjiModel is not null)
            kanjiDetail = _mapper.Map<AdditionalKanjiModel, KanjiDetailOutput>(additionalKanjiModel);

        KanjiComponentModel? kanjiComponentModel = await _kanjiComponentRepository.GetAsync(request.Kanji);
        if (kanjiComponentModel is not null)
            _ = _mapper.Map(kanjiComponentModel, kanjiDetail);

        return new ExecResult<KanjiDetailOutput?>
        {
            Status = ExecStatus.Success,
            Data = kanjiDetail
        };
    }
}
