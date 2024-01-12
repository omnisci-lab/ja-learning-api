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
        Kanjidic2Model? kanjidic2Model = await _kanjidic2Repository.GetByLiteralAsync(request.Kanji!);
        if (kanjidic2Model is null)
            return new ExecResult<KanjiDetailOutput?> { Status = ExecStatus.NotFound };

        Kanjidic2ExtensionModel kanjidic2ExtensionModel = await _kanjidic2ExtensionRepository
            .GetByLiteralAsync(request.Kanji!);

        if (kanjidic2ExtensionModel is not null)
            _mapper.Map(kanjidic2ExtensionModel, kanjidic2Model);

        KanjiDetailOutput kanjiDetail = _mapper.Map<Kanjidic2Model, KanjiDetailOutput>(kanjidic2Model);

        KanjiComponentModel kanjiComponentModel = await _kanjiComponentRepository.GetByLiteralAsync(request.Kanji!);
        if(kanjiComponentModel is not null)
            _mapper.Map(kanjiComponentModel, kanjiDetail);

        return new ExecResult<KanjiDetailOutput?>
        {
            Status = ExecStatus.Success,
            Data = kanjiDetail
        };
    }
}