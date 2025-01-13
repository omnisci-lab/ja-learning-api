using Japanese.Repositories.Interfaces;
using khothemegiatot.WebApi.Enums;
using khothemegiatot.WebApi.Models;
using MediatR;

namespace Japanese.Services.Sentence.Commands.DeleteSentence;

public class DeleteSentenceCommandHandler : IRequestHandler<DeleteSentenceCommand, ExecResult>
{
    private readonly ISentenceRepository _sentenceRepository;

    public DeleteSentenceCommandHandler(IJapaneseRepository japaneseRepository)
    {
        _sentenceRepository = japaneseRepository.SentenceRepository;
    }

    public async Task<ExecResult> Handle(DeleteSentenceCommand request, CancellationToken cancellationToken)
    {
        await _sentenceRepository.DeleteAsync(x => x.SentenceId == request.SentenceId, request.ForceDelete);

        return new ExecResult { Status = ExecStatus.Success };
    }
}