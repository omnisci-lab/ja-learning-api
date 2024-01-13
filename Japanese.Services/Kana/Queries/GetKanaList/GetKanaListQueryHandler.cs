using AutoMapper;
using Japanese.Core.CommonModels;
using Japanese.Models;
using Japanese.Repositories.Interfaces;
using MediatR;

namespace Japanese.Services.Kana.Queries.GetKanaList;

public class GetKanaListQueryHandler : IRequestHandler<GetKanaListQuery, ExecResult<List<KanaDetailOutput>>>
{
    private readonly IKanaRepository _kanaRepository;
    private readonly IMapper _mapper;

    public GetKanaListQueryHandler(IJapaneseRepository repository, IMapper mapper)
    {
        _kanaRepository = repository.KanaRepository;
        _mapper = mapper;
    }

    public async Task<ExecResult<List<KanaDetailOutput>>> Handle(GetKanaListQuery request, CancellationToken cancellationToken)
    {
        List<KanaModel> kanaModels = await _kanaRepository.GetListAsync(request.KanaType!);

        return new ExecResult<List<KanaDetailOutput>>
        {
            Status = Core.Enum.ExecStatus.Success,
            Data = _mapper.Map<List<KanaModel>, List<KanaDetailOutput>>(kanaModels)
        };
    }
}