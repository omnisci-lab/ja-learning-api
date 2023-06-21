using FluentValidation;

namespace Japanese.Application.Features.CommonWord.Commands.CreateCommonWord;

public class CreateCommonWordCommandValidator : AbstractValidator<CreateCommonWordCommand>
{
    public CreateCommonWordCommandValidator()
    {
        RuleFor(r => r.Word)
            .NotEmpty().WithMessage("{Word} is required.")
            .NotNull()
            .MaximumLength(50).WithMessage("{Word} must not exceed 50 characters.");

        RuleFor(r => r.Kana)
            .NotEmpty().WithMessage("{Kana} is required.")
            .NotNull()
            .MaximumLength(50).WithMessage("{Kana} must not exceed 50 characters.");

        RuleFor(r => r.Romaji)
            .NotEmpty().WithMessage("{Kana} is required.")
            .NotNull()
            .MaximumLength(50).WithMessage("{Kana} must not exceed 50 characters.");
    }
}