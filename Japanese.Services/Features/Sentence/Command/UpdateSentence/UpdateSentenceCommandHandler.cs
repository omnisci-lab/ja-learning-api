using Japanese.Domain.Common;
using Japanese.Models;
using Japanese.Repositories.Interfaces;
using MediatR;

namespace Japanese.Services.Features.Sentence.Command.UpdateSentence;

public class UpdateSentenceCommandHandler : IRequestHandler<UpdateSentenceCommand, ExecResult>
{
    private readonly ISentenceRepository _sentenceRepository;

    public UpdateSentenceCommandHandler(IJapaneseRepository japaneseRepository)
    {
        _sentenceRepository = japaneseRepository.SentenceRepository;
    }

    public async Task<ExecResult> Handle(UpdateSentenceCommand request, CancellationToken cancellationToken)
    {
        SentenceModel? sentenceModel = await _sentenceRepository.GetAsync(request.SentenceId);
        if (sentenceModel is null)
            return new ExecResult { Status = ExecStatus.NotFound };


        await _sentenceRepository.SaveItemAsync(sentenceModel);
        return new ExecResult { Status = ExecStatus.Success };
    }
}
