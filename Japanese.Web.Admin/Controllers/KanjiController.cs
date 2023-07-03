using Japanese.Core.CommonModels;
using Japanese.Services.Features.Kanji.Commands.UpdateKanji;
using Japanese.Services.Features.Kanji.Queries.GetKanji;
using Japanese.Services.Features.Kanji.Queries.GetPagedKanji;
using MediatR;
using Microsoft.AspNetCore.Mvc;

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

        
        Pagination<KanjiDetailOutput> paged = await _mediator.Send(query);
        return View(paged);
    }

    [Route("details")]
    public async Task<IActionResult> GetDetails([FromQuery] GetKanjiQuery query)
    {
        query.RefreshCache = true;
        KanjiDetailOutput kanjiDetail = await _mediator.Send(query);
        if (kanjiDetail is null)
            return NotFound();

        return View(kanjiDetail);
    }

    [Route("edit")]
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(UpdateKanjiCommand command)
    {
        ExecResult execResult = await _mediator.Send(command);
        return View(execResult);
    }

    [Route("delete")]
    public async Task<IActionResult> Delete()
    {
        return View();
    }
}