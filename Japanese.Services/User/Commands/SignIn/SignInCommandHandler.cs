using AutoMapper;
using Japanese.Core.CommonModels;
using Japanese.Core.Enum;
using Japanese.LanguageCore.Identity;
using MediatR;

namespace Japanese.Services.Features.User.Commands.SignIn;

public class SignInCommandHandler : IRequestHandler<SignInCommand, ExecResult>
{
    private readonly IIdentityManager _identityManager;
    private readonly IMapper _mapper;

    public SignInCommandHandler(IIdentityManager identityManager, IMapper mapper)
    {
        _identityManager = identityManager;
        _mapper = mapper;
    }

    public async Task<ExecResult> Handle(SignInCommand request, CancellationToken cancellationToken)
    { 
        return new ExecResult { Status = ExecStatus.Success };
    }
}
