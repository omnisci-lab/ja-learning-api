using Japanese.Core.CommonModels;
using Japanese.Core.Enum;
using Japanese.Services.Kanji.Commands.UpdateKanji;
using Japanese.Services.Kanji.Queries.GetKanji;
using Japanese.Services.Kanji.Queries.GetPagedKanji;
using Japanese.Services.Sentence.Commands.DeleteSentence;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebCore.Extensions;

namespace Japanese.Web.Admin.Controllers;

[Route("kanji")]
public class KanjiController : Controller
{
    private readonly IMediator _mediator;

    public KanjiController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [Route("list")]
    public async Task<IActionResult> Index([FromQuery] GetPagedKanjiQuery query)
    {
        if (query.PageSize == 0)
            query.PageSize = 10;

        query.Bypass = true;
        ExecResult<PagedResult<KanjiDetailOutput>> execResult = await _mediator.Send(query);
        if (execResult.Status != ExecStatus.Success)
            return BadRequest();

        return View(execResult.Data);
    }

    [Route("details/{kanji}")]
    public async Task<IActionResult> GetDetails(string kanji)
    {
        GetKanjiQuery query = new GetKanjiQuery() { Kanji = kanji, Bypass = true };
        ExecResult<KanjiDetailOutput?> execResult = await _mediator.Send(query);
        if (execResult.Status == ExecStatus.NotFound)
            return NotFound();

        return View(execResult.Data);
    }

    [Route("edit/{kanji}")]
    [HttpGet]
    public async Task<IActionResult> Edit(string kanji)
    {
        GetKanjiQuery query = new GetKanjiQuery() { Kanji = kanji, Bypass = true };
        ExecResult<KanjiDetailOutput?> execResult = await _mediator.Send(query);
        if (execResult.Status == ExecStatus.NotFound)
            return NotFound();

        if (execResult.Status != ExecStatus.Success)
            return BadRequest();

        KanjiDetailOutput kanjiDetail = execResult.Data!;

        return View(new UpdateKanjiCommand
        {
            Kanji = kanji,
            OnReadings = kanjiDetail.OnReadings,
            KunReadings = kanjiDetail.KunReadings,
            NameReadings = kanjiDetail.NameReadings
        });
    }

    [Route("edit/{kanji}")]
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(UpdateKanjiCommand command)
    {
        ExecResult execResult = await _mediator.Send(command);
        ViewData["ExecResult"] = execResult;

        return View(command);
    }

    [Route("delete")]
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(DeleteSentenceCommand command)
    {
        ExecResult execResult = await _mediator.Send(command);
        TempData.Put("ExecResult", execResult);

        return RedirectToAction("Index");
    }
}