using Japanese.Application.Contracts.Presistence;
using MediatR;

namespace Japanese.Application.Sentence.Queries.GetSentenceList;

public class GetSentenceListQueryHandler : IRequestHandler<GetSentenceListQuery, SentenceOutput>
{
    private readonly ISentenceRepository _sentenceRepository;

    public GetSentenceListQueryHandler(IJapaneseRepository repository)
    {
        _sentenceRepository = repository.SentenceRepository;
    }

    public Task<SentenceOutput> Handle(GetSentenceListQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
