using Japanese.Core.CommonModels;
using Japanese.Core.Enum;
using Japanese.Models;
using Japanese.Repositories.Interfaces;
using MediatR;

namespace Japanese.Services.Features.Sentence.Queries.GetPagedSentences;

public class GetPagedSentencesQueryHandler : IRequestHandler<GetPagedSentencesQuery, ExecResult<Pagination<SentenceOutput>>>
{
    private readonly ISentenceRepository _sentenceRepository;

    public GetPagedSentencesQueryHandler(IJapaneseRepository repository)
    {
        _sentenceRepository = repository.SentenceRepository;
    }

    public async Task<ExecResult<Pagination<SentenceOutput>>> Handle(GetPagedSentencesQuery request, CancellationToken cancellationToken)
    {
        Pagination<SentenceModel> paged = await _sentenceRepository.GetPagedAsync(request);

        return new ExecResult<Pagination<SentenceOutput>>
        {
            Status = ExecStatus.Success,
            Data = new Pagination<SentenceOutput>
            {
                PaginationToken = paged.PaginationToken,
                Items = paged.Items.Select(sentenceModel => new SentenceOutput
                {
                    SentenceId = sentenceModel.SentenceId,
                    Text = sentenceModel.Text,
                    Structure = sentenceModel.Structure,
                    Jlpt = sentenceModel.Jlpt,
                    EnMeanings = sentenceModel.EnMeanings,
                    ViMeanings = sentenceModel.ViMeanings,
                    References = sentenceModel.References
                }).ToList()
            }
        };
    }
}