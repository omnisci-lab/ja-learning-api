using Japanese.Core.API;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Japanese.API.Areas.Admin.Controllers;

[Area("Admin")]
[ApiExplorerSettings(GroupName = "admin")]
[Route("admin-api")]
public class AdminController : ApiControllerBase
{
    public AdminController(IMediator mediator) : base(mediator)
    {
    }
}
