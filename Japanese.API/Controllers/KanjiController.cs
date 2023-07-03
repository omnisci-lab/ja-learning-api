using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Japanese.Services.Features.Kanji.Queries.GetKanji;
using Japanese.API.Base;
using Japanese.Services.Features.Kanji.Commands.UpdateKanji;
using Japanese.Services.Features.Kanji.Commands.CreateKanji;
using Japanese.Services.Features.Kanji.Queries.GetKanjiListByJlpt;
using Japanese.Services.Features.Kanji.Queries.GetPagedKanji;
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
    [Route("list")]
    [ProducesResponseType(typeof(List<object>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetPaged([FromQuery] GetPagedKanjiQuery query)
    {
        Pagination<KanjiDetailOutput> paged = await _mediator.Send(query);
        return Ok(paged);
    }

    [HttpGet]
    [Route("details")]
    [ProducesResponseType(typeof(KanjiDetailOutput), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetDetails([FromQuery] GetKanjiQuery query)
    {
        KanjiDetailOutput kanjiDetail = await _mediator.Send(query);
        if (kanjiDetail == null)
            return NotFound();

        return Ok(kanjiDetail);
    }

    [HttpGet]
    [Route("kanji-list-by-jlpt-level")]
    [ProducesResponseType(typeof(KanjiDetailOutput), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetKanjiListByJlpt([FromQuery] GetKanjiListByJlptQuery query)
    {
        List<KanjiDetailOutput> kanjiList = await _mediator.Send(query);
        return Ok(kanjiList);
    }

    [HttpPost]
    [Route("create-kanji")]
    [ProducesResponseType(typeof(ExecResult), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> Create(CreateKanjiCommand command)
    {
        ExecResult execResult = await _mediator.Send(command);
        return GetResult(execResult);
    }

    [HttpPut]
    [Route("update-kanji")]
    [ProducesResponseType(typeof(ExecResult), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> Update(UpdateKanjiCommand command)
    {
        ExecResult execResult = await _mediator.Send(command);
        return GetResult(execResult);
    }
}
