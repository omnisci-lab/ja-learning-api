using Japanese.API.Base;
using Japanese.Core.CommonModels;
using Japanese.Services.Sentence.Commands.CreateSentence;
using Japanese.Services.Sentence.Commands.DeleteSentence;
using Japanese.Services.Sentence.Commands.UpdateSentence;
using Japanese.Services.Sentence.Queries;
using Japanese.Services.Sentence.Queries.GetPagedSentences;
using Japanese.Services.Sentence.Queries.GetSentence;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Japanese.API.Controllers;

[Route("api/sentence")]
public class SentenceController : ApiControllerBase
{
    private readonly IMediator _mediator;

    public SentenceController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [Route("paged")]
    [HttpGet]
    [ProducesResponseType(typeof(Pagination<SentenceOutput>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetPaged([FromQuery] GetPagedSentencesQuery query)
    {
        return ApiResult(await _mediator.Send(query));
    }

    [Route("details")]
    [HttpGet]
    [ProducesResponseType(typeof(SentenceOutput), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetDetails([FromQuery] GetSentenceQuery query)
    {
        return ApiResult(await _mediator.Send(query));
    }

    [Route("create")]
    [HttpPost]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public async Task<IActionResult> Create(CreateSentenceCommand command)
    {
        return ApiResult(await _mediator.Send(command));
    }

    [Route("update")]
    [HttpPut]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public async Task<IActionResult> Update(UpdateSentenceCommand command)
    {
        return ApiResult(await _mediator.Send(command));
    }

    [Route("delete")]
    [HttpDelete]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public async Task<IActionResult> Delete([FromQuery] DeleteSentenceCommand command)
    {
        return ApiResult(await _mediator.Send(command));
    }
}