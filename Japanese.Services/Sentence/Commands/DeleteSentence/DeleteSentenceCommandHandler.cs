using Japanese.Core.CommonModels;
using Japanese.Core.Enum;
using Japanese.Models;
using Japanese.Repositories.Interfaces;
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
        if (request.ForceDelete)
        {
            await _sentenceRepository.DeleteAsync(request.SentenceId);
            return new ExecResult { Status = ExecStatus.Success };
        }

        SentenceModel? sentenceModel = await _sentenceRepository.GetAsync(request.SentenceId);
        if (sentenceModel is null)
            return new ExecResult { Status = ExecStatus.NotFound };

        sentenceModel.IsDeleted = true;
        await _sentenceRepository.SaveAsync(sentenceModel);

        return new ExecResult { Status = ExecStatus.Success };
    }
}