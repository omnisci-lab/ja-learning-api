using Japanese.Core.CommonModels;
using Japanese.Models;
using Japanese.Repositories.Interfaces;
using MediatR;

namespace Japanese.Services.Features.Kanji.Commands.UpdateKanji;

public class UpdateKanjiCommandHandler : IRequestHandler<UpdateKanjiCommand, ExecResult>
{
    private readonly IKanjiRepository _kanjiRepository;

    public UpdateKanjiCommandHandler(IJapaneseRepository japaneseRepository)
    {
        _kanjiRepository = japaneseRepository.KanjiRepository;
    }

    public async Task<ExecResult> Handle(UpdateKanjiCommand request, CancellationToken cancellationToken)
    {
        KanjiModel? kanjiModel = await _kanjiRepository.GetAsync(request.Kanji);
        if (kanjiModel is null)
            return new ExecResult { Status = ExecStatus.NotFound };



        await _kanjiRepository.SaveItemAsync(kanjiModel);

        return new ExecResult { Status = ExecStatus.Success };
    }
}
