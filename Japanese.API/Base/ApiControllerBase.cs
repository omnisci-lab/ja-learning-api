using Japanese.Domain.Common;
using Microsoft.AspNetCore.Mvc;

namespace Japanese.API.Base;

[ApiController]
[HandlerException]
public class ApiControllerBase : ControllerBase
{
    [NonAction]
    public IActionResult GetResult(ExecResult execResult)
    {
        switch (execResult.Status)
        {
            case ExecStatus.Success: return Ok(execResult);
            case ExecStatus.NotFound: return NotFound(execResult);
            case ExecStatus.AlreadyExists: return Conflict(execResult);
            case ExecStatus.Failed: return BadRequest(execResult);
            default:
                return Ok(execResult);
        }
    }

    [NonAction]
    public IActionResult GetResult<TOutput>(TOutput output)
    {
        if(output is null)
            return NotFound(new ExecResult { Status = ExecStatus.NotFound });

        return Ok(output);
    }
}