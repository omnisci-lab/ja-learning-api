using Japanese.Core.CommonModels;
using Japanese.Domain.Common;
using Japanese.Services.Features.Sentence.Commands.CreateSentence;
using Japanese.Services.Features.Sentence.Commands.UpdateSentence;
using Japanese.Services.Features.Sentence.Queries;
using Japanese.Services.Features.Sentence.Queries.GetPagedSentences;
using Japanese.Services.Features.Sentence.Queries.GetSentence;
using MediatR;
using Microsoft.AspNetCore.Mvc;

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
    public async Task<IActionResult> Index([FromQuery] GetPagedSentencesQuery query)
    {
        if (query.PageSize == 0)
            query.PageSize = 10;

        query.RefreshCache = true;
        Pagination<SentenceOutput> paged = await _mediator.Send(query);
        return View(paged);
    }

    [Route("details/{sentenceId}")]
    public async Task<IActionResult> GetDetails(string sentenceId)
    {
        GetSentenceQuery query = new GetSentenceQuery() { SentenceId = sentenceId, Bypass = true };
        SentenceOutput sentence = await _mediator.Send(query);
        if (sentence is null)
            return NotFound();

        return View(sentence);
    }

    [Route("create")]
    public IActionResult Create()
    {
        return View();
    }

    [Route("create")]
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(CreateSentenceCommand command)
    {
        ExecResult execResult = await _mediator.Send(command);
        return View();
    }

    [Route("edit/{sentenceId}")]
    public async Task<IActionResult> Edit(string sentenceId)
    {
        GetSentenceQuery query = new GetSentenceQuery() { SentenceId = sentenceId, Bypass = true };
        SentenceOutput sentence = await _mediator.Send(query);
        if (sentence is null)
            return NotFound();

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
    public async Task<IActionResult> Edit(UpdateSentenceCommand command)
    {
        ExecResult execResult = await _mediator.Send(command);
        return View();
    }

    [Route("delete")]
    public async Task<IActionResult> Delete()
    {
        return View();
    }
}
