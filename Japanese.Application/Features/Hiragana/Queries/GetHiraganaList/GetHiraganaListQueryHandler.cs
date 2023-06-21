using Japanese.Application.Contracts.Presistence;
using MediatR;

namespace Japanese.Application.Features.Hiragana.Queries.GetHiraganaList;

public class GetHiraganaListQueryHandler : IRequestHandler<GetHiraganaListQuery, List<HiraganaOutput>>
{
    private readonly IHiraganaRepository _hiraganaRepository;

    public GetHiraganaListQueryHandler(IJapaneseRepository repository)
    {
        _hiraganaRepository = repository.HiraganaRepository;
    }

    public async Task<List<HiraganaOutput>> Handle(GetHiraganaListQuery request, CancellationToken cancellationToken)
    {
        return await _hiraganaRepository.GetListAsync(40, s => new HiraganaOutput { 
            Characters = s.Characters
        });
    }
}
