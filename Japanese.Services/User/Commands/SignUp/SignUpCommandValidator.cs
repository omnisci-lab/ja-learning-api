using FluentValidation;

namespace Japanese.Services.Features.User.Commands.SignUp;

public class SignUpCommandValidator : AbstractValidator<SignUpCommand>
{
    public SignUpCommandValidator()
    {
        RuleFor(x => x.Email).NotNull().NotEmpty().EmailAddress();
        RuleFor(x => x.Password).NotNull().NotEmpty();
    }
}