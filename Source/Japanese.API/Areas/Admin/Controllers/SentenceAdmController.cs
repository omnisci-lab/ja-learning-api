using Japanese.Core.CommonModels;
using Japanese.Services.Sentence.Commands.CreateAndUpdateSentence;
using Japanese.Services.Sentence.Commands.DeleteSentence;
using Japanese.Services.Sentence.Queries.GetPagedSentences;
using Japanese.Services.Sentence.Queries.GetSentence;
using Japanese.Services.Sentence.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Japanese.API.Areas.Admin.Controllers;

public class SentenceAdmController : AdminController
{
    public SentenceAdmController(IMediator mediator) : base(mediator)
    {
    }

    [Route("sentence-paged")]
    [HttpPost]
    [ProducesResponseType(typeof(ExecResult<PagedResult<SentenceOutput>>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetPaged([FromQuery] GetPagedSentencesQuery query)
    {
        return await GetObjectResult(query);
    }

    [Route("sentence-details")]
    [HttpPost]
    [ProducesResponseType(typeof(ExecResult<SentenceOutput>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetDetails([FromQuery] GetSentenceQuery query)
    {
        return await GetObjectResult(query);
    }

    [HttpPost]
    [Route("sentence-create-and-update")]
    [ProducesResponseType(typeof(ExecResult), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> CreateAndUpdate([FromBody] CreateAndUpdateSentenceCommand command)
    {
        return await GetObjectResult(command);
    }

    [HttpPost]
    [Route("sentence-delete")]
    [ProducesResponseType(typeof(ExecResult), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> CreateAndUpdate([FromBody] DeleteSentenceCommand command)
    {
        return await GetObjectResult(command);
    }
}
