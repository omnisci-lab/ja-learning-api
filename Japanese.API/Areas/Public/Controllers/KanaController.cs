using Japanese.Core.CommonModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Japanese.Services.Kana.Queries.GetKana;
using Japanese.Services.Kana.Queries;
using Japanese.Services.Kana.Queries.GetKanaList;
using Japanese.Services.Kana.Queries.GetKanaTypes;
using Japanese.Core.API;

namespace Japanese.API.Areas.Public.Controllers;

[Route("public-api/kana")]
public class KanaController : PublicController
{
    public KanaController(IMediator mediator)
        : base(mediator)
    {
    }

    [HttpPost]
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