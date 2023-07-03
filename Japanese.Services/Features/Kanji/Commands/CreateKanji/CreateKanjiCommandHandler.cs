using Japanese.Core.CommonModels;
using Japanese.Core.Enum;
using Japanese.Models;
using Japanese.Repositories.Interfaces;
using MediatR;

namespace Japanese.Services.Features.Kanji.Commands.CreateKanji;

public class CreateKanjiCommandHandler : IRequestHandler<CreateKanjiCommand, ExecResult>
{
    private readonly IKanjiRepository _kanjiRepository;

    public CreateKanjiCommandHandler(IJapaneseRepository japaneseRepository)
    {
        _kanjiRepository = japaneseRepository.KanjiRepository;
    }

    public async Task<ExecResult> Handle(CreateKanjiCommand request, CancellationToken cancellationToken)
    {
        KanjiModel kanjiModel = new KanjiModel
        {

        };

        await _kanjiRepository.SaveItemAsync(kanjiModel);

        return new ExecResult { Status = ExecStatus.Success };
    }
}
