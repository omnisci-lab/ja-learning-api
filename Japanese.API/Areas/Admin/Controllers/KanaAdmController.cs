using Japanese.Core.CommonModels;
using Japanese.Services.Kana.Commands.CreateAndUpdateKana;
using Japanese.Services.Kana.Commands.DeleteKana;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Japanese.API.Areas.Admin.Controllers;

[Route("admin-api")]
public class KanaAdmController : AdminController
{
    public KanaAdmController(IMediator mediator) : base(mediator)
    {
    }

    [HttpPost]
    [Route("create-and-update")]
    [ProducesResponseType(typeof(ExecResult), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> CreateAndUpdate([FromBody] CreateAndUpdateKanaCommand command)
    {
        return await GetObjectResult(command);
    }

    [HttpPost]
    [Route("delete")]
    [ProducesResponseType(typeof(ExecResult), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> Delete([FromBody] DeleteKanaCommand command)
    {
        return await GetObjectResult(command);
    }
}
