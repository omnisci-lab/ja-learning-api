using Japanese.Repositories.Interfaces;
using khothemegiatot.WebApi.Enums;
using khothemegiatot.WebApi.Models;
using MediatR;

namespace Japanese.Services.Kanji.Commands.DeleteKanji;

public class DeleteKanjiCommandHandler : IRequestHandler<DeleteKanjiCommand, ExecResult>
{
    private readonly IKanjiRepository _kanjiRepository;

    public DeleteKanjiCommandHandler(IJapaneseRepository repository)
    {
        _kanjiRepository = repository.KanjiRepository;
    }

    public async Task<ExecResult> Handle(DeleteKanjiCommand request, CancellationToken cancellationToken)
    {
        await _kanjiRepository.DeleteAsync(x => x.Character == request.Character, request.ForceDelete);
        return new ExecResult { Status = ExecStatus.Success };
    }
}
