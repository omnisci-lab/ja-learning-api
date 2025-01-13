using AutoMapper;
using Japanese.Models;
using Japanese.Repositories.Interfaces;
using khothemegiatot.WebApi.Enums;
using khothemegiatot.WebApi.Models;
using MediatR;

namespace Japanese.Services.KanjiRadical.Commands.CreateAndUpdateKRadical;

public class CreateAndUpdateKRadicalCommandHandler : IRequestHandler<CreateAndUpdateKRadicalCommand, ExecResult>
{
    private readonly IKanjiRadicalRepository _kanjiRadicalRepository;
    private readonly IMapper _mapper;

    public CreateAndUpdateKRadicalCommandHandler(IJapaneseRepository repository, IMapper mapper)
    {
        _kanjiRadicalRepository = repository.KanjiRadicalRepository;
        _mapper = mapper;
    }

    public async Task<ExecResult> Handle(CreateAndUpdateKRadicalCommand request, CancellationToken cancellationToken)
    {
        if (request.IsUpdate)
        {
            KanjiRadicalModel kanjiRadicalModel = await _kanjiRadicalRepository.GetByCharacterAsync(request.Character!);
            if (kanjiRadicalModel is null)
                return new ExecResult { Status = ExecStatus.NotFound };

            _ = _mapper.Map(request, kanjiRadicalModel);
            //await _kanjiRadicalRepository.UpdateAsync(kanjiRadicalModel);

            return new ExecResult { Status = ExecStatus.Success };
        }

        bool exists = await _kanjiRadicalRepository.Exists(x => x.Character == request.Character);
        if (!exists)
            return new ExecResult { Status = ExecStatus.AlreadyExists };

        KanjiRadicalModel newKanjiModel = _mapper.Map<CreateAndUpdateKRadicalCommand, KanjiRadicalModel>(request);
        await _kanjiRadicalRepository.InsertAsync(newKanjiModel);

        return new ExecResult { Status = ExecStatus.Success };
    }
}
