using Japanese.Core.API;
using Japanese.Core.CommonModels;
using Japanese.Services.Kana.Queries.GetKana;
using Japanese.Services.Kana.Queries.GetKanaList;
using Japanese.Services.Kana.Queries.GetKanaTypes;
using Japanese.Services.Kana.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Japanese.Admin.API.Controllers;

[Route("api/kana")]
[ApiController]
public class KanaController : ApiControllerBase
{
    public KanaController(IMediator mediator) 
        : base(mediator)
    {
    }

    [Route("list")]
    [ProducesResponseType(typeof(ExecResult<KanaDetailOutput>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetList([FromBody] GetKanaListQuery query)
    {
        return await GetObjectResult(query);
    }

    [HttpPost]
    [Route("types")]
    [ProducesResponseType(typeof(ExecResult<KanaDetailOutput>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetTypes([FromBody] GetKanaTypesQuery query)
    {
        return await GetObjectResult(query);
    }

    [HttpPost]
    [Route("details")]
    [ProducesResponseType(typeof(ExecResult<KanaDetailOutput>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetDetails([FromBody] GetKanaQuery query)
    {
        return await GetObjectResult(query);
    }
}
