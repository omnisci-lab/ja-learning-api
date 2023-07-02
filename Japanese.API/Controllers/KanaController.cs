using Japanese.API.Base;
using MediatR;
using Microsoft.AspNetCore.Components;

namespace Japanese.API.Controllers;

[Route("api/kana")]
public class KanaController : ApiControllerBase
{
    private readonly IMediator _mediator;

    public KanaController(IMediator mediator)
    {
        _mediator = mediator;
    }
}
