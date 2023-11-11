using FluentValidation;

namespace Japanese.Services.Kanji.Queries.GetKanji;

public class GetKanjiQueryValidator : AbstractValidator<GetKanjiQuery>
{
    public GetKanjiQueryValidator()
    {
        RuleFor(x => x.Kanji).NotNull().NotEmpty();
    }
}