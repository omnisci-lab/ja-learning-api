using FluentValidation;

namespace Japanese.Services.Kana.Queries.GetKana;

public class GetKanaQueryValidator : AbstractValidator<GetKanaQuery>
{
    public GetKanaQueryValidator()
    {
        RuleFor(x => x.Character).NotNull().NotEmpty();
    }
}
