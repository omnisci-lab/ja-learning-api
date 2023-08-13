using Japanese.Core.CommonModels;
using MediatR;

namespace Japanese.Services.Features.User.Commands.SignIn;

public class SignInCommand : IRequest<ExecResult>
{
    public string? Email { get; set; }
    public string? Password { get; set; }
}