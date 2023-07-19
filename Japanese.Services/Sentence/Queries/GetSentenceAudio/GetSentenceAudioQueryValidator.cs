using FluentValidation;

namespace Japanese.Services.Sentence.Queries.GetSentenceAudio;

public class GetSentenceAudioQueryValidator : AbstractValidator<GetSentenceAudioQuery>
{
    public GetSentenceAudioQueryValidator()
    {
        RuleFor(x => x.SentenceId).NotNull().NotEmpty();
    }
}
