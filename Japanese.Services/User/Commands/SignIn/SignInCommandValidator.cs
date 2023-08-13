using FluentValidation;

namespace Japanese.Services.Features.User.Commands.SignIn;

public class SignInCommandValidator : AbstractValidator<SignInCommand>
{
    public SignInCommandValidator()
    {
        RuleFor(x => x.Email).NotNull().NotEmpty().EmailAddress();
        RuleFor(x => x.Password).NotNull().NotEmpty();
    }
}
