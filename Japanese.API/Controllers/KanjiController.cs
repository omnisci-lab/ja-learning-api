using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Japanese.Services.Kanji.Queries.GetKanji;
using Japanese.API.Base;
using Japanese.Services.Kanji.Queries.GetPagedKanji;
using Japanese.Core.CommonModels;
using Japanese.Services.Kanji.Queries;
using Japanese.Services.Kanji.Queries.GetSearchProperties;

namespace Japanese.API.Controllers;

[Route("api/kanji")]
public class KanjiController : ApiControllerBase
{
    public KanjiController(IMediator mediator) 
        : base(mediator)
    {

    }

    [HttpPost]
    [Route("paged")]
    [ProducesResponseType(typeof(ExecResult<PagedResult<KanjiDetailOutput>>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetPaged([FromBody] GetPagedKanjiQuery query)
    {
        return await GetObjectResult(query);
    }

    [HttpPost]
    [Route("details")]
    [ProducesResponseType(typeof(ExecResult<KanjiDetailOutput>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetDetails([FromBody] GetKanjiQuery query)
    {
        return await GetObjectResult(query);
    }

    [HttpPost]
    [Route("kanji-search-properties")]
    [ProducesResponseType(typeof(ExecResult<List<string>>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetSearchProperties([FromBody] GetKanjiSearchPropertiesQuery query)
    {
        return await GetObjectResult(query);
    }
}