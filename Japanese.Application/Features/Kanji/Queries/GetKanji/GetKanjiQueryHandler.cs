using Japanese.Application.Contracts.Presistence;
using MediatR;

namespace Japanese.Application.Features.Kanji.Queries.GetKanji;

public class GetKanjiQueryHandler : IRequestHandler<GetKanjiQuery, KanjiDetailOutput?>
{
    private readonly IKanjiRepository _kanjiRepository;

    public GetKanjiQueryHandler(IJapaneseRepository repository)
    {
        _kanjiRepository = repository.KanjiRepository;
    }

    public Task<KanjiDetailOutput?> Handle(GetKanjiQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
