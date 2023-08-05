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
    private readonly IMapper _mapper;

    public GetKanjiQueryHandler(IJapaneseRepository repository, IMapper mapper)
    {
        _kanjidic2Repository = repository.Kanjidic2Repository;
        _kanjiComponentRepository = repository.KanjiComponentRepository;
        _mapper = mapper;
    }

    public async Task<ExecResult<KanjiDetailOutput?>> Handle(GetKanjiQuery request, CancellationToken cancellationToken)
    {
        Kanjidic2Model? kanjidic2Model = await _kanjidic2Repository.GetAsync(request.Kanji);
        if (kanjidic2Model is null)
            return new ExecResult<KanjiDetailOutput?> { Status = ExecStatus.NotFound };

        KanjiDetailOutput kanjiDetail = _mapper.Map<Kanjidic2Model, KanjiDetailOutput>(kanjidic2Model);

        KanjiComponentModel? kanjiComponentModel = await _kanjiComponentRepository.GetAsync(request.Kanji);
        if (kanjiComponentModel is not null)
            kanjiDetail = _mapper.Map(kanjiComponentModel, kanjiDetail);

        return new ExecResult<KanjiDetailOutput?>
        {
            Status = ExecStatus.Success,
            Data = kanjiDetail
        };
    }
}
