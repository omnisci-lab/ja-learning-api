using Japanese.Application.Contracts.Presistence;
using MediatR;

namespace Japanese.Application.Sentence.Queries.GetSentence;

internal class GetSentenceQueryHandler : IRequestHandler<GetSentenceQuery, SentenceOutput?>
{
    private readonly ISentenceRepository _sentenceRepository;

    public GetSentenceQueryHandler(IJapaneseRepository repository)
    {
        _sentenceRepository = repository.SentenceRepository;
    }

    public Task<SentenceOutput?> Handle(GetSentenceQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
