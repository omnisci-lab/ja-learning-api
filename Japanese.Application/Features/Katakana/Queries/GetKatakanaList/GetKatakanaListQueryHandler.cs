using Japanese.Application.Contracts.Presistence;
using MediatR;

namespace Japanese.Application.Features.Katakana.Queries.GetKatakanaList;

public class GetKatakanaListQueryHandler : IRequestHandler<GetKatakanaListQuery, List<KatakanaOutput>>
{
    private readonly IKatakanaRepository _katakanaRepository;

    public GetKatakanaListQueryHandler(IJapaneseRepository repository)
    {
        _katakanaRepository = repository.KatakanaRepository;
    }

    public async Task<List<KatakanaOutput>> Handle(GetKatakanaListQuery request, CancellationToken cancellationToken)
    {
        return await _katakanaRepository.GetListAsync(s => new KatakanaOutput
        {
            Id = s.Id,
            Characters = s.Characters
        });
    }
}
