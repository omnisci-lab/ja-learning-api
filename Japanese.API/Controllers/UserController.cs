using Japanese.API.Base;
using Japanese.Core.CommonModels;
using Japanese.Services.Features.User.Commands.SignIn;
using Japanese.Services.Features.User.Commands.SignUp;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Japanese.API.Controllers;

[Route("api/user")]
[ApiController]
public class UserController : ApiControllerBase
{
    public UserController(IMediator mediator)
        : base(mediator)
    {
    }

    [HttpPost]
    [Route("sign-up")]
    [ProducesResponseType(typeof(ExecResult), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> SignUp([FromBody] SignUpCommand command)
    {
        return await GetObjectResult(command);
    }

    [HttpPost]
    [Route("sign-in")]
    [ProducesResponseType(typeof(ExecResult), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> SignIn([FromBody] SignInCommand command)
    {
        return await GetObjectResult(command);
    }
}
