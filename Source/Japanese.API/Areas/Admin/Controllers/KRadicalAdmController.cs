using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Japanese.API.Areas.Admin.Controllers;

[Route("api/radical")]
[ApiController]
public class KRadicalAdmController : AdminController
{
    private readonly IMediator _mediator;

    public KRadicalAdmController(IMediator mediator) : base(mediator)
    {
    }
}