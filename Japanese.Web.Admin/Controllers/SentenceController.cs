using Japanese.Core.CommonModels;
using Japanese.Core.Enum;
using Japanese.Services.Features.Sentence.Commands.CreateSentence;
using Japanese.Services.Features.Sentence.Commands.DeleteSentence;
using Japanese.Services.Features.Sentence.Commands.UpdateSentence;
using Japanese.Services.Features.Sentence.Queries;
using Japanese.Services.Features.Sentence.Queries.GetPagedSentences;
using Japanese.Services.Features.Sentence.Queries.GetSentence;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebCore.Attributes;
using WebCore.Extensions;

namespace Japanese.Web.Admin.Controllers;

[Route("sentence")]
public class SentenceController : Controller
{
    private readonly IMediator _mediator;

    public SentenceController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [Route("list")]
    [PageTitle(Title = "List of Sentences")]
    public async Task<IActionResult> Index([FromQuery] GetPagedSentencesQuery query)
    {
        if (query.PageSize == 0)
            query.PageSize = 10;

        query.RefreshCache = true;
        ExecResult<Pagination<SentenceOutput>> execResult = await _mediator.Send(query);
        if (execResult.Status != ExecStatus.Success)
            return BadRequest();

        return View(execResult.Data);
    }

    [Route("details/{sentenceId}")]
    [PageTitle(Title = "Sentence Details")]
    public async Task<IActionResult> GetDetails(string sentenceId)
    {
        GetSentenceQuery query = new GetSentenceQuery() { SentenceId = sentenceId, Bypass = true };
        ExecResult<SentenceOutput?> execResult = await _mediator.Send(query);
        if (execResult.Status == ExecStatus.NotFound)
            return NotFound();

        if (execResult.Status != ExecStatus.Success)
            return BadRequest();

        return View(execResult.Data);
    }

    [Route("create")]
    [PageTitle(Title = "Create new a Sentences")]
    public IActionResult Create()
    {
        return View(new CreateSentenceCommand { Jlpt = 1 });
    }

    [Route("create")]
    [HttpPost]
    [ValidateAntiForgeryToken]
    [PageTitle(Title = "Create new a Sentences")]
    public async Task<IActionResult> Create(CreateSentenceCommand command)
    {
        ExecResult execResult = await _mediator.Send(command);
        ViewData["ExecResult"] = execResult;

        return View();
    }

    [Route("edit/{sentenceId}")]
    [PageTitle(Title = "Edit a Sentences")]
    public async Task<IActionResult> Edit(string sentenceId)
    {
        GetSentenceQuery query = new GetSentenceQuery() { SentenceId = sentenceId, Bypass = true };
        ExecResult<SentenceOutput?> execResult = await _mediator.Send(query);
        if (execResult.Status == ExecStatus.NotFound)
            return NotFound();

        if (execResult.Status != ExecStatus.Success)
            return BadRequest();

        SentenceOutput sentence = execResult.Data!;

        return View(new UpdateSentenceCommand { 
            SentenceId = sentence.SentenceId,
            Text = sentence.Text,
            EnMeanings = sentence.EnMeanings,
            ViMeanings = sentence.ViMeanings
        });
    }

    [Route("edit/{sentenceId}")]
    [HttpPost]
    [ValidateAntiForgeryToken]
    [PageTitle(Title = "Edit a Sentences")]
    public async Task<IActionResult> Edit(UpdateSentenceCommand command)
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