using Japanese.Application.Contracts.Presistence;
using MediatR;

namespace Japanese.Application.Features.Katakana.Queries.GetKatakana;

public class GetKatakanaQueryHandler : IRequestHandler<GetKatakanaQuery, KatakanaOutput?>
{
    private IKatakanaRepository _katakanaRepository;

    public GetKatakanaQueryHandler(IJapaneseRepository repository)
    {
        _katakanaRepository = repository.KatakanaRepository;
    }

    public async Task<KatakanaOutput?> Handle(GetKatakanaQuery request, CancellationToken cancellationToken)
    {
        return await _katakanaRepository.GetAsync(request.KatakanaId, s => new KatakanaOutput
        {
            Id = s.Id,
            Characters = s.Characters
        });
    }
}
