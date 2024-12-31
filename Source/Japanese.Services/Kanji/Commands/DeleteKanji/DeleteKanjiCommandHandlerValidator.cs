using FluentValidation;

namespace Japanese.Services.Kanji.Commands.DeleteKanji;

public class DeleteKanjiCommandHandlerValidator : AbstractValidator<DeleteKanjiCommand>
{
    public DeleteKanjiCommandHandlerValidator()
    {
        RuleFor(x => x.Character).NotNull().NotEmpty();
    }
}