using AutoMapper;
using Japanese.Core.CommonModels;
using Japanese.Core.Enum;
using Japanese.Models;
using Japanese.Repositories.Interfaces;
using MediatR;

namespace Japanese.Services.Kanji.Commands.CreateKanji;

public class CreateKanjiCommandHandler : IRequestHandler<CreateKanjiCommand, ExecResult>
{
    //private readonly IKanjidic2ExtensionRepository _kanjidic2ExtensionRepository;
    private readonly IMapper _mapper;

    public CreateKanjiCommandHandler(IJapaneseRepository japaneseRepository, IMapper mapper)
    {
        //_kanjidic2ExtensionRepository = japaneseRepository.Kanjidic2ExtensionRepository;
        _mapper = mapper;
    }

    public async Task<ExecResult> Handle(CreateKanjiCommand request, CancellationToken cancellationToken)
    {
        Kanjidic2ExtensionModel kanjiModel = _mapper.Map<CreateKanjiCommand, Kanjidic2ExtensionModel>(request);

        //await _kanjidic2ExtensionRepository.SaveAsync(kanjiModel);

        return new ExecResult { Status = ExecStatus.Success };
    }
}