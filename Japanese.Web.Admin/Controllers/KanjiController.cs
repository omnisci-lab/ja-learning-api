using Japanese.Core.CommonModels;
using Japanese.Core.Enum;
using Japanese.Services.Kanji.Commands.CreateKanji;
using Japanese.Services.Kanji.Commands.UpdateKanji;
using Japanese.Services.Kanji.Queries.GetKanji;
using Japanese.Services.Kanji.Queries.GetPagedKanji;
using Japanese.Services.Sentence.Commands.DeleteSentence;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebCore.Attributes;
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
    [PageTitle(Title = "List of Sentences")]
    public async Task<IActionResult> Index([FromQuery] GetPagedKanjiQuery query)
    {
        if (query.PageSize == 0)
            query.PageSize = 20;

        query.Bypass = true;
        ExecResult<PagedResult<KanjiDetailOutput>> execResult = await _mediator.Send(query);
        if (execResult.Status != ExecStatus.Success)
            return BadRequest();

        return View(execResult.Data);
    }

    [Route("details/{kanji}")]
    [PageTitle(Title = "Kanji Details")]
    public async Task<IActionResult> GetDetails(string kanji)
    {
        GetKanjiQuery query = new GetKanjiQuery() { Kanji = kanji, Bypass = true };
        ExecResult<KanjiDetailOutput?> execResult = await _mediator.Send(query);
        if (execResult.Status == ExecStatus.NotFound)
            return NotFound();

        return View(execResult.Data);
    }

    [Route("create")]
    [PageTitle(Title = "Create new a Kanji")]
    public IActionResult Create()
    {
        return View(new CreateKanjiCommand { Jlpt = 1 });
    }

    [Route("create")]
    [HttpPost]
    [ValidateAntiForgeryToken]
    [PageTitle(Title = "Create new a Kanji")]
    public async Task<IActionResult> Create(CreateKanjiCommand command)
    {
        ExecResult execResult = await _mediator.Send(command);
        ViewData["ExecResult"] = execResult;

        return View();
    }

    [Route("edit/{kanji}")]
    [HttpGet]
    [PageTitle(Title = "Edit a Kanji")]
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
            StrokeCount = kanjiDetail.StrokeCount,
            Grade = kanjiDetail.Grade,
            OnReadings = kanjiDetail.OnReadings,
            KunReadings = kanjiDetail.KunReadings,
            NameReadings = kanjiDetail.NameReadings,
            EnMeanings = kanjiDetail.EnMeanings,
            ViMeanings = kanjiDetail.ViMeanings,
            SinoVietnamese = kanjiDetail.SinoVietnamese
        });
    }

    [Route("edit/{kanji}")]
    [HttpPost]
    [ValidateAntiForgeryToken]
    [PageTitle(Title = "Edit a Kanji")]
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