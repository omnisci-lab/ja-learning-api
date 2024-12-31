using FluentValidation;

namespace Japanese.Services.CommonWord.Queries.GetCommonWord;

public class GetCommonWordQueryValidator : AbstractValidator<GetCommonWordQuery>
{
    public GetCommonWordQueryValidator()
    {
        RuleFor(x => x.WordId).NotNull().NotEmpty();
    }
}