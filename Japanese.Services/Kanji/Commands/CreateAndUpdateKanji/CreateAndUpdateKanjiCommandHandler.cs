using AutoMapper;
using Japanese.Core.CommonModels;
using Japanese.Core.Enum;
using Japanese.Models;
using Japanese.Repositories.Interfaces;
using MediatR;

namespace Japanese.Services.Kanji.Commands.CreateAndUpdateKanji;

public class CreateAndUpdateKanjiCommandHandler : IRequestHandler<CreateAndUpdateKanjiCommand, ExecResult>
{
    private readonly IKanjiRepository _kanjiRepository;
    private readonly IMapper _mapper;

    public CreateAndUpdateKanjiCommandHandler(IJapaneseRepository repository, IMapper mapper)
    {
        _kanjiRepository = repository.KanjiRepository;
        _mapper = mapper;
    }

    public async Task<ExecResult> Handle(CreateAndUpdateKanjiCommand request, CancellationToken cancellationToken)
    {
        if(request.IsUpdate)
        {
            KanjiModel kanjiModel = await _kanjiRepository.GetByLiteralAsync(request.Kanji!);
            if (kanjiModel is null)
                return new ExecResult { Status = ExecStatus.NotFound };

            _mapper.Map(request, kanjiModel);
            await _kanjiRepository.UpdateAsync(kanjiModel);

            return new ExecResult { Status = ExecStatus.Success };
        }

        KanjiModel newKanjiModel = _mapper.Map<CreateAndUpdateKanjiCommand, KanjiModel>(request);
        await _kanjiRepository.InsertAsync(newKanjiModel);

        return new ExecResult { Status = ExecStatus.Success };
    }
}
