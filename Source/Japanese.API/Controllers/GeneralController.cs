using khothemegiatot.WebApi.CQRS.Controllers;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Japanese.API.Controllers;

[Route("api")]
[Authorize]
public class GeneralController : ApiControllerBase
{
    public GeneralController(IMediator mediator) : base(mediator)
    {
    }
}
