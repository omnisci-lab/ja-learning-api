using Japanese.Core.API;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Japanese.Admin.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SentenceController : ApiControllerBase
{
    public SentenceController(IMediator mediator) 
        : base(mediator)
    {
    }
}