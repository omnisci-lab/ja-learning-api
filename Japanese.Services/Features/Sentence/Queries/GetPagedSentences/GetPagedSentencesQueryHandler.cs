using Japanese.Core.CommonModels;
using Japanese.Models;
using Japanese.Repositories.Interfaces;
using MediatR;

namespace Japanese.Services.Features.Sentence.Queries.GetPagedSentences;

public class GetPagedSentencesQueryHandler : IRequestHandler<GetPagedSentencesQuery, Pagination<SentenceOutput>>
{
    private readonly ISentenceRepository _sentenceRepository;

    public GetPagedSentencesQueryHandler(IJapaneseRepository repository)
    {
        _sentenceRepository = repository.SentenceRepository;
    }

    public async Task<Pagination<SentenceOutput>> Handle(GetPagedSentencesQuery request, CancellationToken cancellationToken)
    {
        Pagination<SentenceModel> paged = await _sentenceRepository.GetPagedAsync(request);

        return new Pagination<SentenceOutput>
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
        };
    }
}