using Japanese.Core.CommonModels;
using Japanese.Core.Enum;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Japanese.API.Base;

[ApiController]
[HandlerException]
public class ApiControllerBase : ControllerBase
{
    private readonly IMediator _mediator;

    public ApiControllerBase(IMediator mediator)
    {
        _mediator = mediator;
    }

    [NonAction]
    public async Task<ObjectResult> ApiResult<TResponse>(IRequest<TResponse> request, CancellationToken cancellationToken = default)
        where TResponse : ExecResult
    {
        TResponse response = await _mediator.Send(request, cancellationToken);
        switch (response.Status)
        {
            case ExecStatus.Success: return Ok(response);
            case ExecStatus.NotFound: return NotFound(response);
            case ExecStatus.AlreadyExists: return Conflict(response);
            case ExecStatus.Invalid:
            case ExecStatus.Failed: return BadRequest(response);
            default:
                return Ok(response);
        }
    }

    [NonAction]
    public async Task<ObjectResult> ApiResult(IRequest request, CancellationToken cancellationToken = default)
    {
        await _mediator.Send(request, cancellationToken);
        return Ok(new ExecResult { Status = ExecStatus.Success });
    }
}