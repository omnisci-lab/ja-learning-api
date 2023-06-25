using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Japanese.Services.Features.Kanji.Queries.GetKanji;
using Japanese.API.Base;
using Japanese.Domain.Common;
using Japanese.Services.Features.Kanji.Command.UpdateKanji;
using Japanese.Services.Features.Kanji.Command.CreateKanji;

namespace Japanese.API.Controllers;

[Route("api/kanji")]
public class KanjiController : ApiControllerBase
{
    private readonly IMediator _mediator;

    public KanjiController(IMediator mediator)
    {
        _mediator = mediator;
    }

    //[HttpGet]
    //[Route("list")]
    //[ProducesResponseType(typeof(List<KanjiOutput>), (int)HttpStatusCode.OK)]
    //public async Task<IActionResult> GetList()
    //{
    //    return Ok(await _mediator.Send(new GetKanjiListQuery()));
    //}

    [HttpGet]
    [Route("details/{kanji}")]
    [ProducesResponseType(typeof(KanjiDetailOutput), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetDetails(string kanji)
    {
        GetKanjiQuery getKanjiQuery = new GetKanjiQuery { Kanji = kanji };
        KanjiDetailOutput kanjiDetail = await _mediator.Send(getKanjiQuery);
        if (kanjiDetail == null)
            return NotFound();

        return Ok(kanji);
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
