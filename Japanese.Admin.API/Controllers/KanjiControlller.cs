using Japanese.Core.API;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Japanese.Admin.API.Controllers;

[Route("api/kanji")]
[ApiController]
public class KanjiController : ApiControllerBase
{
    public KanjiController(IMediator mediator) 
        : base(mediator)
    {
    }
}
