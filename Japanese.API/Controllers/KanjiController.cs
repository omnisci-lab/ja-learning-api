using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Japanese.Application.Features.Kanji.Queries.GetKanjiList;
using Japanese.Application.Features.Kanji.Queries.GetKanji;
using Japanese.API.Base;

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
    [ProducesResponseType(typeof(List<KanjiOutput>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetList()
    {
        return Ok(await _mediator.Send(new GetKanjiListQuery()));
    }

    [HttpGet]
    [Route("details/{kanjiId}")]
    [ProducesResponseType(typeof(KanjiOutput), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetDetails(string kanjiId)
    {
        GetKanjiQuery getKanjiQuery = new GetKanjiQuery { KanjiId = kanjiId };
        KanjiDetailOutput kanji = await _mediator.Send(getKanjiQuery);
        if (kanji == null)
            return NotFound();

        return Ok(kanji);
    }
}
