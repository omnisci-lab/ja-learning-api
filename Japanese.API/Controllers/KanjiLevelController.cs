using Japanese.API.Base;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Japanese.API.Controllers;

[Route("api/[controller]")]
public class KanjiLevelController : ApiControllerBase
{
    private IMediator _mediator;

    public KanjiLevelController(IMediator mediator)
    {
        _mediator = mediator;
    }
}
