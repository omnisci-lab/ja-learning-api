using AutoMapper;
using IdentityCore.Models;
using Japanese.Core.CommonModels;
using Japanese.Core.Enum;
using Japanese.LanguageCore.Identity;
using MediatR;

namespace Japanese.Services.Features.User.Commands.SignUp;

public class SignUpCommandHandler : IRequestHandler<SignUpCommand, ExecResult>
{
    private readonly IIdentityManager _identityManager;
    private readonly IMapper _mapper;

    public SignUpCommandHandler(IIdentityManager identityManager, IMapper mapper)
    {
        _identityManager = identityManager;
        _mapper = mapper;
    }

    public async Task<ExecResult> Handle(SignUpCommand request, CancellationToken cancellationToken)
    {
        UserModel userModel = _mapper.Map<SignUpCommand, UserModel>(request);

        await _identityManager.CreateUserAsync(userModel);

        return new ExecResult { Status = ExecStatus.Success };
    }
}