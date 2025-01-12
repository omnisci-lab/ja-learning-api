using AutoMapper;
using Japanese.Models;
using Japanese.Repositories.Interfaces;
using khothemegiatot.WebApi.Enums;
using khothemegiatot.WebApi.Models;
using MediatR;

namespace Japanese.Services.Kana.Queries.GetKana;

public class GetKanaQueryHandler : IRequestHandler<GetKanaQuery, ExecResult<KanaDetailOutput?>>
{
    private readonly IKanaRepository _kanaRepository;
    private readonly IMapper _mapper;

    public GetKanaQueryHandler(IJapaneseRepository repository, IMapper mapper)
    {
        _kanaRepository = repository.KanaRepository;
        _mapper = mapper;
    }

    public async Task<ExecResult<KanaDetailOutput?>> Handle(GetKanaQuery request, CancellationToken cancellationToken)
    {
        KanaModel? kanaModel = await _kanaRepository.GetByCharacterAsync(request.Character!);
        if (kanaModel is null)
            return new ExecResult<KanaDetailOutput?> { Status = ExecStatus.NotFound };

        return new ExecResult<KanaDetailOutput?>
        {
            Status = ExecStatus.Success,
            Data = _mapper.Map<KanaModel, KanaDetailOutput>(kanaModel)
        };
    }
}