using Japanese.API.Base;
using Japanese.Application.Sentence.Commands.CreateSentence;
using Japanese.Application.Sentence.Queries;
using Japanese.Application.Sentence.Queries.GetSentence;
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

    [Route("details/{sentenceId}")]
    [HttpGet]
    [ProducesResponseType(typeof(SentenceOutput), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetDetails(string sentenceId)
    {
        GetSentenceQuery getSentenceQuery = new GetSentenceQuery { SentenceId = sentenceId };
        SentenceOutput sentence = await _mediator.Send(getSentenceQuery);
        if (sentence == null)
            return NotFound();

        return Ok(sentence);
    }

    [Route("create")]
    [HttpPost]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public async Task<IActionResult> Create(CreateSentenceCommand input)
    {
        int result = await _mediator.Send(input);

        return Ok();
    }
}
