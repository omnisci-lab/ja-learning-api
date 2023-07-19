using Japanese.API.Base;
using MediatR;
using Microsoft.AspNetCore.Components;

namespace Japanese.API.Controllers;

[Route("api/kana")]
public class KanaController : ApiControllerBase
{
    public KanaController(IMediator mediator) 
        : base(mediator)
    {
    }
}
