using AutoMapper;
using Japanese.Core.CommonModels;
using Japanese.Core.Enum;
using Japanese.Models;
using Japanese.Repositories.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Japanese.Services.Features.User.Commands.SignIn
{
    public class SignInCommandHandler : IRequestHandler<SignInCommand, ExecResult>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public SignInCommandHandler(IJapaneseRepository japaneseRepository, IMapper mapper)
        {
            _userRepository = japaneseRepository.UserRepository;
            _mapper = mapper;
        }


        public async Task<ExecResult> Handle(SignInCommand request, CancellationToken cancellationToken)
        {
            UserModel userModel = _mapper.Map<SignInCommand, UserModel>(request);

            //UserModel user = await _userRepository.GetUserByEmailAsync(request.Email);

            //if (user != null)
            //    return new ExecResult { Status = ExecStatus.AlreadyExists };

            //await _userRepository.SaveAsync(userModel);

            return new ExecResult { Status = ExecStatus.Success };
        }
    }
}
