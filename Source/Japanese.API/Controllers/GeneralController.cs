using khothemegiatot.WebApi.CQRS.Controllers;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Japanese.API.Controllers;

[Route("api")]
public class GeneralController : ApiControllerBase
{
    public GeneralController(IMediator mediator) : base(mediator)
    {
    }
}
