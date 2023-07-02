using Japanese.Models;
using Japanese.Repositories.Interfaces;
using MediatR;

namespace Japanese.Services.Features.Sentence.Queries.SearchSentences;

public class SearchSentencesQueryHandler : IRequestHandler<SearchSentencesQuery, List<SentenceOutput>>
{
    private readonly ISentenceRepository _sentenceRepository;

    public SearchSentencesQueryHandler(IJapaneseRepository repository)
    {
        _sentenceRepository = repository.SentenceRepository;
    }

    public async Task<List<SentenceOutput>> Handle(SearchSentencesQuery request, CancellationToken cancellationToken)
    {
        List<SentenceModel> sentenceModels = await _sentenceRepository.SearchAsync("vi-meanings", request.Keyword);

        await _sentenceRepository.CountItemsAsync();

        return sentenceModels.Select(s => new SentenceOutput
        {
            SentenceId = s.SentenceId,
            Text = s.Text,
            EnMeanings = s.EnMeanings,
            ViMeanings = s.ViMeanings
        }).ToList();
    }
}