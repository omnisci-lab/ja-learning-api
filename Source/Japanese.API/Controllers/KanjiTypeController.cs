using Japanese.API.Base;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Japanese.API.Controllers;

[Route("api/kanji-type")]
public class KanjiTypeController : ApiControllerBase
{
    private readonly IMediator _mediator;

    public KanjiTypeController(IMediator mediator)
    {
        _mediator = mediator;
    }
}
