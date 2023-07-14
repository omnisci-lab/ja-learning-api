using AutoMapper;
using Japanese.Core.CommonModels;
using Japanese.Core.Enum;
using Japanese.Models;
using Japanese.Repositories.Interfaces;
using MediatR;

namespace Japanese.Services.Kanji.Commands.CreateKanji;

public class CreateKanjiCommandHandler : IRequestHandler<CreateKanjiCommand, ExecResult>
{
    private readonly IKanjiRepository _kanjiRepository;
    private readonly IMapper _mapper;

    public CreateKanjiCommandHandler(IJapaneseRepository japaneseRepository, IMapper mapper)
    {
        _kanjiRepository = japaneseRepository.KanjiRepository;
        _mapper = mapper;
    }

    public async Task<ExecResult> Handle(CreateKanjiCommand request, CancellationToken cancellationToken)
    {
        KanjiModel kanjiModel = _mapper.Map<CreateKanjiCommand, KanjiModel>(request);

        await _kanjiRepository.SaveItemAsync(kanjiModel);

        return new ExecResult { Status = ExecStatus.Success };
    }
}
