using Japanese.Models;
using Japanese.Repositories.Interfaces;
using MediatR;

namespace Japanese.Services.Features.Sentence.Queries.GetSentence;

public class GetSentenceQueryHandler : IRequestHandler<GetSentenceQuery, SentenceOutput?>
{
    private readonly ISentenceRepository _sentenceRepository;

    public GetSentenceQueryHandler(IJapaneseRepository repository)
    {
        _sentenceRepository = repository.SentenceRepository;
    }

    public async Task<SentenceOutput?> Handle(GetSentenceQuery request, CancellationToken cancellationToken)
    {
        SentenceModel? sentenceModel = await _sentenceRepository.GetAsync(request.SentenceId);
        if (sentenceModel is null)
            return null;

        return new SentenceOutput
        {

        };
    }
}
