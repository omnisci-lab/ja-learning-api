using Japanese.Core.API;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Japanese.API.Areas.Public.Controllers;

[Area("Public")]
[ApiExplorerSettings(GroupName = "public")]
public class PublicController : ApiControllerBase
{
    public PublicController(IMediator mediator) : base(mediator)
    {
    }
}
