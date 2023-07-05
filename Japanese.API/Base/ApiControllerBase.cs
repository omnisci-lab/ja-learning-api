using Japanese.Core.CommonModels;
using Japanese.Core.Enum;
using Microsoft.AspNetCore.Mvc;

namespace Japanese.API.Base;

[ApiController]
[HandlerException]
public class ApiControllerBase : ControllerBase
{
    [NonAction]
    public ObjectResult ApiResult<T>(T value) where T : ExecResult
    {
        switch (value.Status)
        {
            case ExecStatus.Success: return Ok(value);
            case ExecStatus.NotFound: return NotFound(value);
            case ExecStatus.AlreadyExists: return Conflict(value);
            case ExecStatus.Invalid:
            case ExecStatus.Failed: return BadRequest(value);
            default:
                return Ok(value);
        }
    }
}