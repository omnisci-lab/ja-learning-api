using Japanese.Application.Contracts.Presistence;
using MediatR;

namespace Japanese.Application.Features.CommonWord.Queries.GetCommonWordMeaning;

public class GetCommonWordMeaningQueryHandler : IRequestHandler<GetCommonWordMeaningQuery, CommonWordMeaningOutput>
{
    private ICommonWordRepository _commonWordRepository;

    public GetCommonWordMeaningQueryHandler(IJapaneseRepository japaneseRepository)
    {
        _commonWordRepository = japaneseRepository.CommonWordRepository;
    }

    public async Task<CommonWordMeaningOutput> Handle(GetCommonWordMeaningQuery request, CancellationToken cancellationToken)
    {
        CommonWordMeaningOutput commonWordMeaning = null!;
        switch (request.LanguageCode)
        {
            case "vi": break;
            case "en": break;
        }

        return commonWordMeaning;
    }
}