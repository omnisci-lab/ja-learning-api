using AutoMapper;
using Japanese.Core.CommonModels;
using Japanese.Core.Enum;
using Japanese.Models;
using Japanese.Repositories.Interfaces;
using MediatR;

namespace Japanese.Services.Kanji.Commands.UpdateKanji;

public class UpdateKanjiCommandHandler : IRequestHandler<UpdateKanjiCommand, ExecResult>
{
    private readonly IKanjidic2ExtensionRepository _kanjidic2ExtensionRepository;
    private readonly IMapper _mapper;

    public UpdateKanjiCommandHandler(IJapaneseRepository japaneseRepository, IMapper mapper)
    {
        _kanjidic2ExtensionRepository = japaneseRepository.Kanjidic2ExtensionRepository;
        _mapper = mapper;
    }

    public async Task<ExecResult> Handle(UpdateKanjiCommand request, CancellationToken cancellationToken)
    {
        Kanjidic2ExtensionModel? kanjiModel = await _kanjidic2ExtensionRepository.GetAsync(request.Kanji);
        if (kanjiModel is null)
            return new ExecResult { Status = ExecStatus.NotFound };

        _mapper.Map(request, kanjiModel);

        await _kanjidic2ExtensionRepository.SaveAsync(kanjiModel);

        return new ExecResult { Status = ExecStatus.Success };
    }
}
