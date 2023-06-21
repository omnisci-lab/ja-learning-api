using Japanese.Application.Contracts.Presistence;
using Japanese.Domain.Common;
using MediatR;

namespace Japanese.Application.Features.CommonWord.Queries.GetCommonWordPaged;

public class GetCommonWordPagedQueryHandler : IRequestHandler<GetCommonWordPagedQuery, Pagination<CommonWordPagedOutput>>
{
    private ICommonWordRepository _commonWordRepository;

    public GetCommonWordPagedQueryHandler(IJapaneseRepository japaneseRepository)
    {
        _commonWordRepository = japaneseRepository.CommonWordRepository;
    }

    public async Task<Pagination<CommonWordPagedOutput>> Handle(GetCommonWordPagedQuery request, CancellationToken cancellationToken)
    {
        return await _commonWordRepository.GetPagedAsync(request, s => new CommonWordPagedOutput
        {
            Id = s.Id,
            Word = s.Word,
            Kana = s.Kana,
            Romaji = s.Romaji
        });
    }
}