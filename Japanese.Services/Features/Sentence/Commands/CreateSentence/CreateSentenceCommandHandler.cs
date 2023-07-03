using Japanese.Core.CommonModels;
using Japanese.Core.Enum;
using Japanese.Models;
using Japanese.Repositories.Interfaces;
using MediatR;

namespace Japanese.Services.Features.Sentence.Commands.CreateSentence;

public class CreateSentenceCommandHandler : IRequestHandler<CreateSentenceCommand, ExecResult>
{
    private readonly ISentenceRepository _sentenceRepository;

    public CreateSentenceCommandHandler(IJapaneseRepository japaneseRepository)
    {
        _sentenceRepository = japaneseRepository.SentenceRepository;
    }

    public async Task<ExecResult> Handle(CreateSentenceCommand request, CancellationToken cancellationToken)
    {
        SentenceModel sentenceModel = new SentenceModel
        {
            SentenceId = Guid.NewGuid().ToString(),
            Text = request.Text,
            Structure = request.Structure,
            Jlpt = request.Jlpt,
            EnMeanings = request.EnMeanings,
            ViMeanings = request.ViMeanings,
            References = request.References,
            CreatedDate = DateTime.Now
        };

        await _sentenceRepository.SaveItemAsync(sentenceModel);

        return new ExecResult { Status = ExecStatus.Success };
    }
}