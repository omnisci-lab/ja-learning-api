using Japanese.API.Base;
using Japanese.Application.Features.Hiragana.Queries;
using Japanese.Application.Features.Hiragana.Queries.GetHiragana;
using Japanese.Application.Features.Hiragana.Queries.GetHiraganaList;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Japanese.API.Controllers;

[Route("api/hiragana")]
public class HiraganaController : ApiControllerBase
{
    private readonly IMediator _mediator;

    public HiraganaController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("list")]
    [ProducesResponseType(typeof(List<HiraganaOutput>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetList()
    {
        return Ok(await _mediator.Send(new GetHiraganaListQuery()));
    }

    [HttpGet]
    [Route("details/{hiraganaId}")]
    [ProducesResponseType(typeof(HiraganaOutput), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetDetails(string hiraganaId)
    {
        GetHiraganaQuery getHiraganaQuery = new GetHiraganaQuery { HiraganaId = hiraganaId };
        HiraganaOutput hiragana = await _mediator.Send(getHiraganaQuery);
        if (hiragana == null)
            return NotFound();

        return Ok(hiragana);
    }
}
