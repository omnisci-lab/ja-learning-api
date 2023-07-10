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
    private readonly IMediator _mediator;

    public KanjiController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("paged")]
    [ProducesResponseType(typeof(List<object>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetPaged([FromQuery] GetPagedKanjiQuery query)
    {
        return Ok(await _mediator.Send(query));
    }

    [HttpGet]
    [Route("details")]
    [ProducesResponseType(typeof(KanjiDetailOutput), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetDetails([FromQuery] GetKanjiQuery query)
    {
        return Ok(await _mediator.Send(query));
    }

    [HttpGet]
    [Route("kanji-list-by-jlpt-level")]
    [ProducesResponseType(typeof(KanjiDetailOutput), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetKanjiListByJlpt([FromQuery] GetKanjiListByJlptQuery query)
    {
        return Ok(await _mediator.Send(query));
    }

    [HttpPost]
    [Route("create-kanji")]
    [ProducesResponseType(typeof(ExecResult), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> Create(CreateKanjiCommand command)
    {
        return ApiResult(await _mediator.Send(command));
    }

    [HttpPut]
    [Route("update-kanji")]
    [ProducesResponseType(typeof(ExecResult), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> Update(UpdateKanjiCommand command)
    {
        return ApiResult(await _mediator.Send(command));
    }
}