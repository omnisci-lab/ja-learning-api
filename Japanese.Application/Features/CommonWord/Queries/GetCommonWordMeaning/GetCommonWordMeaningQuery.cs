using MediatR;

namespace Japanese.Application.Features.CommonWord.Queries.GetCommonWordMeaning;

public class GetCommonWordMeaningQuery : IRequest<CommonWordMeaningOutput>
{
    public string? LanguageCode { get; set; }
    public string? WordId { get; set; }
}
