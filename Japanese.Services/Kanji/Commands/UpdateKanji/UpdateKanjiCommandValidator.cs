using FluentValidation;

namespace Japanese.Services.Kanji.Commands.UpdateKanji;

public class UpdateKanjiCommandValidator : AbstractValidator<UpdateKanjiCommand>
{
    public UpdateKanjiCommandValidator()
    {
        RuleFor(r => r.Kanji).NotNull().NotEmpty();
    }
}
