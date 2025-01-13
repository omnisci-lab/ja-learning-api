using AutoMapper;
using Japanese.Models;
using Japanese.Repositories.Interfaces;
using khothemegiatot.WebApi.Enums;
using khothemegiatot.WebApi.Models;
using MediatR;

namespace Japanese.Services.KanjiRadical.Queries.GetKRadical;

public class GetKRadicalQueryHandler : IRequestHandler<GetKRadicalQuery, ExecResult<KRadicalDetailOutput>>
{
    private readonly IKanjiRadicalRepository _kanjiRadicalRepository;
    private readonly IMapper _mapper;

    public GetKRadicalQueryHandler(IJapaneseRepository repository, IMapper mapper)
    {
        _kanjiRadicalRepository = repository.KanjiRadicalRepository;
        _mapper = mapper;
    }

    public async Task<ExecResult<KRadicalDetailOutput>> Handle(GetKRadicalQuery request, CancellationToken cancellationToken)
    {
        KanjiRadicalModel radicalModel = await _kanjiRadicalRepository.GetByCharacterAsync(request.Character!);
        if (radicalModel is null) 
            return new ExecResult<KRadicalDetailOutput>
            {
                Status = ExecStatus.Success,
                Data = null
            };

        KRadicalDetailOutput kRadicalDetail = _mapper.Map<KanjiRadicalModel, KRadicalDetailOutput>(radicalModel);

        return new ExecResult<KRadicalDetailOutput>
        {
            Status = ExecStatus.Success,
            Data = kRadicalDetail
        };
    }
}
