using Japanese.Core.CommonModels;
using Japanese.Core.Enum;
using Japanese.Services.Sentence.Commands.CreateSentence;
using Japanese.Services.Sentence.Commands.DeleteSentence;
using Japanese.Services.Sentence.Commands.UpdateSentence;
using Japanese.Services.Sentence.Consts;
using Japanese.Services.Sentence.Queries;
using Japanese.Services.Sentence.Queries.GetPagedSentences;
using Japanese.Services.Sentence.Queries.GetSentence;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;
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
    [HttpGet]
    public async Task<IActionResult> Index([FromQuery] GetPagedSentencesQuery query)
    {
        if (query.PageSize == 0)
            query.PageSize = 10;

        query.Bypass = true;
        ExecResult<PagedResult<SentenceOutput>> execResult = await _mediator.Send(query);
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
    [PageTitle(Title = "Create new a Sentence")]
    public IActionResult Create()
    {
        return View(new CreateSentenceCommand { Jlpt = 1 });
    }

    [Route("create")]
    [HttpPost]
    [ValidateAntiForgeryToken]
    [PageTitle(Title = "Create new a Sentence")]
    public async Task<IActionResult> Create(CreateSentenceCommand command)
    {
        ExecResult execResult = await _mediator.Send(command);
        ViewData["ExecResult"] = execResult;

        return View();
    }

    [Route("edit/{sentenceId}")]
    [PageTitle(Title = "Edit a Sentence")]
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
            Jlpt = sentence.Jlpt,
            Structure = sentence.Structure,
            EnMeaning = sentence.EnMeaning,
            ViMeaning = sentence.ViMeaning,
            References = sentence.References
        });
    }

    [Route("edit/{sentenceId}")]
    [HttpPost]
    [ValidateAntiForgeryToken]
    [PageTitle(Title = "Edit a Sentence")]
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