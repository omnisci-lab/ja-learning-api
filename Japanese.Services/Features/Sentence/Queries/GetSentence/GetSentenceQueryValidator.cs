using FluentValidation;

namespace Japanese.Services.Features.Sentence.Queries.GetSentence;

public class GetSentenceQueryValidator : AbstractValidator<GetSentenceQuery>
{
    public GetSentenceQueryValidator()
    {
        RuleFor(x => x.SentenceId).NotNull().NotEmpty();
    }
}
