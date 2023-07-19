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
using System.Net.Http.Headers;

namespace Japanese.API.Controllers;

[Route("api/sentence")]
public class SentenceController : ApiControllerBase
{
    private IMediator mediator;

    public SentenceController(IMediator mediator) 
        : base(mediator)
    {
        this.mediator = mediator;
    }

    [Route("paged")]
    [HttpGet]
    [ProducesResponseType(typeof(ExecResult<PagedResult<SentenceOutput>>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetPaged([FromQuery] GetPagedSentencesQuery query)
    {
        return await ApiResult(query);
    }

    [Route("details")]
    [HttpGet]
    [ProducesResponseType(typeof(ExecResult<SentenceOutput>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetDetails([FromQuery] GetSentenceQuery query)
    {
        return await ApiResult(query);
    }

    [Route("get-audio")]
    [HttpGet]
    [ProducesResponseType(typeof(ExecResult<SentenceOutput>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetAudio([FromQuery] GetSentenceAudioQuery query)
    {
        ExecResult<MemoryStream> execResult = await mediator.Send(query);
        using(MemoryStream s = execResult.Data!)
        {
            Response.ContentType = new MediaTypeHeaderValue("audio/mpeg").ToString();
            return File(s.ToArray(), "audio/mpeg");
            //return new FileStreamResult(s, "audio/mpeg");
        };
    }

    [Route("create")]
    [HttpPost]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public async Task<IActionResult> Create(CreateSentenceCommand command)
    {
        return await ApiResult(command);
    }

    [Route("update")]
    [HttpPut]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public async Task<IActionResult> Update(UpdateSentenceCommand command)
    {
        return await ApiResult(command);
    }

    [Route("delete")]
    [HttpDelete]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public async Task<IActionResult> Delete([FromQuery] DeleteSentenceCommand command)
    {
        return await ApiResult(command);
    }
}