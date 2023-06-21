using Japanese.Application.Contracts.Presistence;
using MediatR;

namespace Japanese.Application.Features.Kanji.Queries.GetKanjiList;

public class GetKanjiListQueryHandler : IRequestHandler<GetKanjiListQuery, KanjiOutput>
{
    private readonly IKanjiRepository _kanjiRepository;

    public GetKanjiListQueryHandler(IJapaneseRepository repository)
    {
        _kanjiRepository = repository.KanjiRepository;
    }

    public Task<KanjiOutput> Handle(GetKanjiListQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}