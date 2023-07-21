using Japanese.API.Base;
using Japanese.Core.CommonModels;
using Japanese.Services.Sentence.Commands.CreateSentence;
using Japanese.Services.Sentence.Commands.DeleteSentence;
using Japanese.Services.Sentence.Commands.UpdateSentence;
using Japanese.Services.Sentence.Queries;
using Japanese.Services.Sentence.Queries.GetPagedSentences;
using Japanese.Services.Sentence.Queries.GetSentence;
using Japanese.Services.Sentence.Queries.GetSentenceAudio;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Japanese.API.Controllers;

[Route("api/sentence")]
public class SentenceController : ApiControllerBase
{
    public SentenceController(IMediator mediator) 
        : base(mediator)
    {

    }

    [Route("paged")]
    [HttpGet]
    [ProducesResponseType(typeof(ExecResult<PagedResult<SentenceOutput>>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetPaged([FromQuery] GetPagedSentencesQuery query)
    {
        return await GetObjectResult(query);
    }

    [Route("details")]
    [HttpGet]
    [ProducesResponseType(typeof(ExecResult<SentenceOutput>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetDetails([FromQuery] GetSentenceQuery query)
    {
        return await GetObjectResult(query);
    }

    [Route("get-audio")]
    [HttpGet]
    [ProducesResponseType(typeof(Core.CommonModels.FileResult), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetAudio([FromQuery] GetSentenceAudioQuery query)
    {
        return await GetFileResult(query);
    }

    [Route("create")]
    [HttpPost]
    [ProducesResponseType(typeof(ExecResult), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> Create(CreateSentenceCommand command)
    {
        return await GetObjectResult(command);
    }

    [Route("update")]
    [HttpPut]
    [ProducesResponseType(typeof(ExecResult), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> Update(UpdateSentenceCommand command)
    {
        return await GetObjectResult(command);
    }

    [Route("delete")]
    [HttpDelete]
    [ProducesResponseType(typeof(ExecResult), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> Delete([FromQuery] DeleteSentenceCommand command)
    {
        return await GetObjectResult(command);
    }
}