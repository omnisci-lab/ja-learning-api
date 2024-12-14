using Japanese.Core.CommonModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Japanese.Services.Kanji.Commands.CreateAndUpdateKanji;

namespace Japanese.API.Areas.Admin.Controllers;

[Route("admin-api/kanji")]
public class KanjiAdmController : AdminController
{
    public KanjiAdmController(IMediator mediator) : base(mediator)
    {
    }

    [HttpPost]
    [Route("create-and-update")]
    [ProducesResponseType(typeof(ExecResult), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> CreateAndUpdate([FromBody] CreateAndUpdateKanjiCommand command)
    {
        return await GetObjectResult(command);
    }
}