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
    private readonly IKanjidic2ExtensionRepository _kanjidic2ExtensionRepository;
    private readonly IKanjiComponentRepository _kanjiComponentRepository;
    private readonly IMapper _mapper;

    public GetKanjiQueryHandler(IJapaneseRepository repository, IMapper mapper)
    {
        _kanjidic2Repository = repository.Kanjidic2Repository;
        _kanjidic2ExtensionRepository = repository.Kanjidic2ExtensionRepository;
        _kanjiComponentRepository = repository.KanjiComponentRepository;
        _mapper = mapper;
    }

    public async Task<ExecResult<KanjiDetailOutput?>> Handle(GetKanjiQuery request, CancellationToken cancellationToken)
    {
        Kanjidic2Model? kanjidic2Model = await _kanjidic2Repository.GetAsync(request.Kanji);
        Kanjidic2ExtensionModel? kanjidic2ExtensionModel = await _kanjidic2ExtensionRepository.GetAsync(request.Kanji);
        if (kanjidic2ExtensionModel is not null)
            _ = _mapper.Map(kanjidic2ExtensionModel, kanjidic2Model);

        if (kanjidic2Model is null && kanjidic2ExtensionModel is null)
            return new ExecResult<KanjiDetailOutput?> { Status = ExecStatus.NotFound };

        if (kanjidic2Model is not null && kanjidic2ExtensionModel is not null)
            _ = _mapper.Map(kanjidic2Model, kanjidic2ExtensionModel);
        
        if (kanjidic2Model is not null && kanjidic2ExtensionModel is null)
            kanjidic2ExtensionModel = _mapper.Map<Kanjidic2Model, Kanjidic2ExtensionModel>(kanjidic2Model);

        KanjiDetailOutput? kanjiDetail = null;
        if (kanjidic2ExtensionModel is not null)
            kanjiDetail = _mapper.Map<Kanjidic2ExtensionModel, KanjiDetailOutput>(kanjidic2ExtensionModel);

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