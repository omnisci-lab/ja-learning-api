using Japanese.Core.CommonModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Japanese.Services.Features.User.Commands.SignUp
{
    public class SignUpCommand : IRequest<ExecResult>
    {
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
    }
}
