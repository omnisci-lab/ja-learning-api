using AutoMapper;
using Japanese.Core.CommonModels;
using Japanese.Core.Enum;
using Japanese.Models;
using Japanese.Repositories.Interfaces;
using MediatR;

namespace Japanese.Services.Kanji.Queries.GetKanji;

public class GetKanjiQueryHandler : IRequestHandler<GetKanjiQuery, ExecResult<KanjiDetailOutput?>>
{
    private readonly IKanjiRepository _kanjiRepository;
    private readonly IMapper _mapper;

    public GetKanjiQueryHandler(IJapaneseRepository repository, IMapper mapper)
    {
        _kanjiRepository = repository.KanjiRepository;
        _mapper = mapper;
    }

    public async Task<ExecResult<KanjiDetailOutput?>> Handle(GetKanjiQuery request, CancellationToken cancellationToken)
    {
        KanjiModel? kanjiModel = await _kanjiRepository.GetAsync(request.Kanji);
        if (kanjiModel is null)
            return new ExecResult<KanjiDetailOutput?> { Status = ExecStatus.NotFound };

        return new ExecResult<KanjiDetailOutput?>
        {
            Status = ExecStatus.Success,
            Data = _mapper.Map<KanjiModel, KanjiDetailOutput>(kanjiModel)
        };
    }
}
