using FluentValidation;

namespace Japanese.Services.Features.Sentence.Commands.CreateSentence;

public class CreateSentenceCommandValidator : AbstractValidator<CreateSentenceCommand>
{
    public CreateSentenceCommandValidator()
    {
        RuleFor(x => x.Text).NotNull().NotEmpty();
        RuleFor(x => x.Jlpt).GreaterThanOrEqualTo(1).LessThanOrEqualTo(5);
        RuleFor(x => x.ViMeanings).NotEmpty();
    }
}
