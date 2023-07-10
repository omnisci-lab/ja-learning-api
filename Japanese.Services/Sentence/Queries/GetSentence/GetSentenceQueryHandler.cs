using Japanese.Core.CommonModels;
using Japanese.Core.Enum;
using Japanese.Models;
using Japanese.Repositories.Interfaces;
using MediatR;

namespace Japanese.Services.Sentence.Queries.GetSentence;

public class GetSentenceQueryHandler : IRequestHandler<GetSentenceQuery, ExecResult<SentenceOutput?>>
{
    private readonly ISentenceRepository _sentenceRepository;

    public GetSentenceQueryHandler(IJapaneseRepository repository)
    {
        _sentenceRepository = repository.SentenceRepository;
    }

    public async Task<ExecResult<SentenceOutput?>> Handle(GetSentenceQuery request, CancellationToken cancellationToken)
    {
        SentenceModel? sentenceModel = await _sentenceRepository.GetAsync(request.SentenceId);
        if (sentenceModel is null)
            return new ExecResult<SentenceOutput?> { Status = ExecStatus.NotFound };

        return new ExecResult<SentenceOutput?>
        {
            Status = ExecStatus.Success,
            Data = new SentenceOutput
            {
                SentenceId = sentenceModel.SentenceId,
                Text = sentenceModel.Text,
                Structure = sentenceModel.Structure,
                Jlpt = sentenceModel.Jlpt,
                EnMeanings = sentenceModel.EnMeanings,
                ViMeanings = sentenceModel.ViMeanings,
                References = sentenceModel.References
            }
        };
    }
}
