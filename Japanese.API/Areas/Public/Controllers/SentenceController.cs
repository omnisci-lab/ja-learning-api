using Japanese.Core.CommonModels;
using Japanese.Services.Sentence.Queries;
using Japanese.Services.Sentence.Queries.GetPagedSentences;
using Japanese.Services.Sentence.Queries.GetSentence;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Japanese.API.Areas.Public.Controllers;

[Route("public-api")]
public class SentenceController : PublicController
{
    public SentenceController(IMediator mediator)
        : base(mediator)
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
}