using Japanese.Core.CommonModels;
using Japanese.Services.Sentence.Commands.CreateAndUpdateSentence;
using Japanese.Services.Sentence.Commands.DeleteSentence;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Japanese.API.Areas.Admin.Controllers;

[Route("admin-api/sentence")]
public class SentenceAdmController : AdminController
{
    public SentenceAdmController(IMediator mediator) : base(mediator)
    {
    }

    [HttpPost]
    [Route("create-and-update")]
    [ProducesResponseType(typeof(ExecResult), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> CreateAndUpdate([FromBody] CreateAndUpdateSentenceCommand command)
    {
        return await GetObjectResult(command);
    }

    [HttpPost]
    [Route("delete")]
    [ProducesResponseType(typeof(ExecResult), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> CreateAndUpdate([FromBody] DeleteSentenceCommand command)
    {
        return await GetObjectResult(command);
    }
}
