using FluentValidation;

namespace Japanese.Services.Sentence.Commands.DeleteSentence;

public class DeleteSentenceCommandValidator : AbstractValidator<DeleteSentenceCommand>
{
    public DeleteSentenceCommandValidator()
    {
        RuleFor(x => x.SentenceId).NotNull().NotEmpty();
    }
}
