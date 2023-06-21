using Japanese.Application.Contracts.Presistence;
using MediatR;

namespace Japanese.Application.Features.Hiragana.Queries.GetHiragana;

public class GetHiraganaQueryHandler : IRequestHandler<GetHiraganaQuery, HiraganaOutput?>
{
    private IHiraganaRepository _hiraganaRepository;

    public GetHiraganaQueryHandler(IJapaneseRepository repository)
    {
        _hiraganaRepository = repository.HiraganaRepository;
    }

    public async Task<HiraganaOutput?> Handle(GetHiraganaQuery request, CancellationToken cancellationToken)
    {
        Dictionary<string, object?> ids = new Dictionary<string, object?>()
        {
            { "Id", request.HiraganaId }
        };

        return await _hiraganaRepository.GetByPkAsync(ids, s => new HiraganaOutput
        {
            Characters = s.Characters
        });
    }
}
