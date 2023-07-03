using Japanese.Core.CommonModels;
using Japanese.Core.Enum;
using Japanese.Repositories.Interfaces;
using MediatR;

namespace Japanese.Services.Features.Sentence.Commands.DeleteSentence;

public class DeleteSentenceCommandHandler : IRequestHandler<DeleteSentenceCommand, ExecResult>
{
    private readonly ISentenceRepository _sentenceRepository;

    public DeleteSentenceCommandHandler(IJapaneseRepository japaneseRepository)
    {
        _sentenceRepository = japaneseRepository.SentenceRepository;
    }

    public async Task<ExecResult> Handle(DeleteSentenceCommand request, CancellationToken cancellationToken)
    {
        await _sentenceRepository.DeleteItemAsync(request.SentenceId);

        return new ExecResult { Status = ExecStatus.Success };
    }
}
