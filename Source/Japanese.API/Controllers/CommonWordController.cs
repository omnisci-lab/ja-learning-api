using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Japanese.Application.Features.CommonWord.Queries.GetCommonWord;
using System.ComponentModel.DataAnnotations;
using Japanese.Application.Features.CommonWord.Commands.CreateCommonWord;
using Japanese.Domain.Common;
using Japanese.API.Base;
using Japanese.Application.Features.CommonWord.Commands.UpdateCommonWord;
using Japanese.Application.Features.CommonWord.Commands.BatchDeleteCommonWord;
using Japanese.Application.Features.CommonWord.Queries.GetCommonWordPaged;
using Japanese.Application.Features.CommonWord.Commands.ForceDeleteCommonWord;
using Japanese.Application.Features.CommonWord.Queries.GetCommonWordMeaning;

namespace Japanese.API.Controllers;

[Route("api/common-word")]
public class CommonWordController : ApiControllerBase
{
    private readonly IMediator _mediator;

    public CommonWordController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    [Route("list")]
    [ProducesResponseType(typeof(Pagination<CommonWordPagedOutput>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetPaged([FromBody] GetCommonWordPagedQuery input)
    {
        Pagination<CommonWordPagedOutput> pagination = await _mediator.Send(input);
        return GetResult(pagination);
    }

    [HttpGet]
    [Route("details/{wordId}")]
    [ProducesResponseType(typeof(CommonWordOutput), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetDetails([Required] string wordId)
    {
        CommonWordOutput? commonWord = await _mediator.Send(new GetCommonWordQuery { WordId = wordId });
        return GetResult(commonWord);
    }

    [HttpPost]
    [Route("create")]
    [ProducesResponseType(typeof(ExecResult), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> Create([FromBody] CreateCommonWordCommand input)
    {
        ExecResult execResult = await _mediator.Send(input);
        return GetResult(execResult);
    }

    [HttpPut]
    [Route("edit")]
    [ProducesResponseType(typeof(ExecResult), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> Edit([FromBody] UpdateCommonWordCommand input)
    {
        ExecResult execResult = await _mediator.Send(input);
        return GetResult(execResult);
    }

    [HttpDelete]
    [Route("batch-delete")]
    [ProducesResponseType(typeof(ExecResult), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> BatchDelete([FromBody] BatchDeleteCommonWordCommand input)
    {
        ExecResult execResult = await _mediator.Send(input);
        return GetResult(execResult);
    }

    [HttpDelete]
    [Route("force-delete")]
    [ProducesResponseType(typeof(ExecResult), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> ForceDelete([FromBody] ForceDeleteCommonWordCommand input)
    {
        ExecResult execResult = await _mediator.Send(input);
        return GetResult(execResult);
    }

    [HttpPost]
    [Route("get-meaning")]
    [ProducesResponseType(typeof(CommonWordMeaningOutput), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetMeaning([FromBody] GetCommonWordMeaningQuery input)
    {
        CommonWordMeaningOutput commonWordMeaning = await _mediator.Send(input);
        return GetResult(commonWordMeaning);
    }

    [HttpPost]
    [Route("add-meaning")]
    [ProducesResponseType(typeof(CommonWordMeaningOutput), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> AddMeaning([FromBody] GetCommonWordMeaningQuery input)
    {
        CommonWordMeaningOutput commonWordMeaning = await _mediator.Send(input);
        return GetResult(commonWordMeaning);
    }
}
