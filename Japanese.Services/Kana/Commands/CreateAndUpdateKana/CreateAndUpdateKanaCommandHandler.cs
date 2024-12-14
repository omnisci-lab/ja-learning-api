using AutoMapper;
using Japanese.Core.CommonModels;
using Japanese.Core.Enum;
using Japanese.Repositories.Interfaces;
using MediatR;
using Japanese.Models;

namespace Japanese.Services.Kana.Commands.CreateAndUpdateKana;

public class CreateAndUpdateKanaCommandHandler : IRequestHandler<CreateAndUpdateKanaCommand, ExecResult>
{
    private readonly IKanaRepository _kanaRepository;
    private readonly IMapper _mapper;

    public CreateAndUpdateKanaCommandHandler(IJapaneseRepository repository, IMapper mapper)
    {
        _kanaRepository = repository.KanaRepository;
        _mapper = mapper;
    }

    public async Task<ExecResult> Handle(CreateAndUpdateKanaCommand request, CancellationToken cancellationToken)
    {
        if (request.IsUpdate)
        {
            KanaModel kanaModel = await _kanaRepository.GetByCharacterAsync(request.Character!);
            if (kanaModel is null)
                return new ExecResult { Status = ExecStatus.NotFound };

            _ = _mapper.Map(request, kanaModel);
            await _kanaRepository.UpdateAsync(kanaModel);

            return new ExecResult { Status = ExecStatus.Success };
        }

        bool exists = await _kanaRepository.Exists(x => x.Character == request.Character!);
        if (!exists)
            return new ExecResult { Status = ExecStatus.AlreadyExists };

        KanaModel newKanaModel = _mapper.Map<CreateAndUpdateKanaCommand, KanaModel>(request);
        await _kanaRepository.InsertAsync(newKanaModel);

        return new ExecResult { Status = ExecStatus.Success };
    }
}
