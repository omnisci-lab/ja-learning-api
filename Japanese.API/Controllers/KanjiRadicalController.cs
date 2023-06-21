using Japanese.API.Base;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Japanese.API.Controllers;

[Route("api/radical")]
[ApiController]
public class KanjiRadicalController : ApiControllerBase
{
    private readonly IMediator _mediator;

    public KanjiRadicalController(IMediator mediator)
    {
        _mediator = mediator;
    }
}