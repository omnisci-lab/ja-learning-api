using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Japanese.Services.Kanji.Queries.GetKanji;
using Japanese.API.Base;
using Japanese.Services.Kanji.Commands.UpdateKanji;
using Japanese.Services.Kanji.Commands.CreateKanji;
using Japanese.Services.Kanji.Queries.GetKanjiListByJlpt;
using Japanese.Services.Kanji.Queries.GetPagedKanji;
using Japanese.Core.CommonModels;

namespace Japanese.API.Controllers;

[Route("api/kanji")]
public class KanjiController : ApiControllerBase
{
    public KanjiController(IMediator mediator) 
        : base(mediator)
    {

    }

    [HttpGet]
    [Route("paged")]
    [ProducesResponseType(typeof(ExecResult<PagedResult<KanjiDetailOutput>>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetPaged([FromQuery] GetPagedKanjiQuery query)
    {
        return await GetObjectResult(query);
    }

    [HttpGet]
    [Route("details")]
    [ProducesResponseType(typeof(ExecResult<KanjiDetailOutput>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetDetails([FromQuery] GetKanjiQuery query)
    {
        return await GetObjectResult(query);
    }

    [HttpGet]
    [Route("kanji-list-by-jlpt-level")]
    [ProducesResponseType(typeof(ExecResult<PagedResult<KanjiDetailOutput>>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetKanjiListByJlpt([FromQuery] GetKanjiListByJlptQuery query)
    {
        return await GetObjectResult(query);
    }

    [HttpPost]
    [Route("create-kanji")]
    [ProducesResponseType(typeof(ExecResult), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> Create(CreateKanjiCommand command)
    {
        return await GetObjectResult(command);
    }

    [HttpPut]
    [Route("update-kanji")]
    [ProducesResponseType(typeof(ExecResult), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> Update(UpdateKanjiCommand command)
    {
        return await GetObjectResult(command);
    }
}