using FluentValidation;

namespace Japanese.Services.Kana.Queries.GetKanaList;

public class GetKanaListQueryValidator : AbstractValidator<GetKanaListQuery>
{
    public GetKanaListQueryValidator()
    {
        RuleFor(x => x.KanaType).NotNull().NotEmpty();
    }
}