using Japanese.Core.CommonModels;
using Japanese.Models;
using Japanese.Repositories.Interfaces;
using MediatR;

namespace Japanese.Services.Features.Sentence.Commands.UpdateSentence;

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

        sentenceModel.Text = request.Text;
        sentenceModel.Structure = request.Structure;
        sentenceModel.Jlpt = request.Jlpt;
        sentenceModel.EnMeanings = request.EnMeanings;
        sentenceModel.ViMeanings = request.ViMeanings;
        sentenceModel.References = request.References;
        sentenceModel.LastModifiedDate = DateTime.Now;

        await _sentenceRepository.SaveItemAsync(sentenceModel);
        return new ExecResult { Status = ExecStatus.Success };
    }
}
