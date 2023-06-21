using Japanese.Application.Contracts.Presistence;
using MediatR;

namespace Japanese.Application.Features.CommonWord.Queries.GetCommonWord;

public class GetCommonWordQueryHandler : IRequestHandler<GetCommonWordQuery, CommonWordOutput?>
{
    private ICommonWordRepository _commonWordRepository;

    public GetCommonWordQueryHandler(IJapaneseRepository japaneseRepository)
    {
        _commonWordRepository = japaneseRepository.CommonWordRepository;
    }

    public Task<CommonWordOutput?> Handle(GetCommonWordQuery request, CancellationToken cancellationToken)
    {
        Dictionary<string, object?> ids = new Dictionary<string, object?>
        {
            { "Id", request.WordId }
        };

        return _commonWordRepository.GetByPkAsync(ids, s => new CommonWordOutput
        {
            Id = s.Id,
            Word = s.Word,
            Kana = s.Kana,
            Romaji = s.Romaji
        });
    }
}