using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Japanese.Application.Features.Katakana.Queries;
using Japanese.Application.Features.Katakana.Queries.GetKatakanaList;
using Japanese.Application.Features.Katakana.Queries.GetKatakana;
using Japanese.API.Base;

namespace Japanese.API.Controllers;

[Route("api/katakana")]
public class KatakanaController : ApiControllerBase
{
    private readonly IMediator _mediator;

    public KatakanaController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("list")]
    [ProducesResponseType(typeof(List<KatakanaOutput>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetList()
    {
        return Ok(await _mediator.Send(new GetKatakanaListQuery()));
    }

    [HttpGet]
    [Route("details/{katakanaId}")]
    [ProducesResponseType(typeof(KatakanaOutput), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetDetails(string katakanaId)
    {
        GetKatakanaQuery getKatakanaQuery = new GetKatakanaQuery { KatakanaId = katakanaId };
        KatakanaOutput katakana = await _mediator.Send(getKatakanaQuery);
        if (katakana == null)
            return NotFound();

        return Ok(katakana);
    }
}
