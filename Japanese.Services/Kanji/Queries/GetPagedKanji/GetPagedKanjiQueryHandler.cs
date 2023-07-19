using AutoMapper;
using Japanese.Core.CommonModels;
using Japanese.Core.Enum;
using Japanese.Models;
using Japanese.Repositories.Interfaces;
using Japanese.Services.Kanji.Queries.GetKanji;
using MediatR;

namespace Japanese.Services.Kanji.Queries.GetPagedKanji;

public class GetPagedKanjiQueryHandler : IRequestHandler<GetPagedKanjiQuery, ExecResult<PagedResult<KanjiDetailOutput>>>
{
    private readonly IKanjiRepository _kanjiRepository;
    private readonly IMapper _mapper;

    public GetPagedKanjiQueryHandler(IJapaneseRepository japaneseRepository, IMapper mapper)
    {
        _kanjiRepository = japaneseRepository.KanjiRepository;
        _mapper = mapper;
    }

    public async Task<ExecResult<PagedResult<KanjiDetailOutput>>> Handle(GetPagedKanjiQuery request, CancellationToken cancellationToken)
    {
        PagedResult<KanjiModel> paged_raw = await _kanjiRepository.GetPagedAsync(request);

        return new ExecResult<PagedResult<KanjiDetailOutput>>
        {
            Status = ExecStatus.Success,
            Data = _mapper.Map<PagedResult<KanjiModel>, PagedResult<KanjiDetailOutput>>(paged_raw)
        };
    }
}