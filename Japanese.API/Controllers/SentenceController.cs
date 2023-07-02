using Japanese.API.Base;
using Japanese.Domain.Common;
using Japanese.Services.Features.Sentence.Commands.CreateSentence;
using Japanese.Services.Features.Sentence.Commands.DeleteSentence;
using Japanese.Services.Features.Sentence.Commands.UpdateSentence;
using Japanese.Services.Features.Sentence.Queries;
using Japanese.Services.Features.Sentence.Queries.GetSentence;
using Japanese.Services.Features.Sentence.Queries.SearchSentences;
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

    [Route("details")]
    [HttpGet]
    [ProducesResponseType(typeof(SentenceOutput), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetDetails([FromQuery] GetSentenceQuery query)
    {
        SentenceOutput sentence = await _mediator.Send(query);
        if (sentence == null)
            return NotFound();

        return Ok(sentence);
    }

    [Route("search")]
    [HttpGet]
    [ProducesResponseType(typeof(List<SentenceOutput>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> Search([FromQuery] SearchSentencesQuery query)
    {
        List<SentenceOutput> sentences = await _mediator.Send(query);
        return Ok(sentences);
    }

    [Route("create")]
    [HttpPost]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public async Task<IActionResult> Create(CreateSentenceCommand command)
    {
        ExecResult execResult = await _mediator.Send(command);

        return GetResult(execResult);
    }

    [Route("update")]
    [HttpPut]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public async Task<IActionResult> Update(UpdateSentenceCommand command)
    {
        ExecResult execResult = await _mediator.Send(command);

        return GetResult(execResult);
    }

    [Route("delete")]
    [HttpDelete]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public async Task<IActionResult> Delete([FromQuery] DeleteSentenceCommand command)
    {
        ExecResult execResult = await _mediator.Send(command);

        return GetResult(execResult);
    }
}
