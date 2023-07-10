using FluentValidation;

namespace Japanese.Services.Kanji.Commands.CreateKanji;

public class CreateKanjiCommandValidator : AbstractValidator<CreateKanjiCommand>
{
    public CreateKanjiCommandValidator()
    {
        RuleFor(x => x.Kanji).NotNull().NotEmpty();
    }
}
