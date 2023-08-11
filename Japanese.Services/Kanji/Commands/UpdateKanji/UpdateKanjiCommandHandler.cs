using AutoMapper;
using Japanese.Core.CommonModels;
using Japanese.Core.Enum;
using Japanese.Models;
using Japanese.Repositories.Interfaces;
using MediatR;

namespace Japanese.Services.Kanji.Commands.UpdateKanji;

public class UpdateKanjiCommandHandler : IRequestHandler<UpdateKanjiCommand, ExecResult>
{
    private readonly IAdditionalKanjiRepository _kanjiRepository;
    private readonly IMapper _mapper;

    public UpdateKanjiCommandHandler(IJapaneseRepository japaneseRepository, IMapper mapper)
    {
        _kanjiRepository = japaneseRepository.AdditionalKanjiRepository;
        _mapper = mapper;
    }

    public async Task<ExecResult> Handle(UpdateKanjiCommand request, CancellationToken cancellationToken)
    {
        AdditionalKanjiModel? kanjiModel = await _kanjiRepository.GetAsync(request.Kanji);
        if (kanjiModel is null)
            return new ExecResult { Status = ExecStatus.NotFound };

        _mapper.Map(request, kanjiModel);

        await _kanjiRepository.SaveAsync(kanjiModel);

        return new ExecResult { Status = ExecStatus.Success };
    }
}
