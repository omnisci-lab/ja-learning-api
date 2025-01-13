using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Japanese.Services.Kana.Queries.GetKana;
using Japanese.Services.Kana.Queries;
using Japanese.Services.Kana.Queries.GetKanaList;
using Japanese.Services.Kana.Queries.GetKanaTypes;
using khothemegiatot.WebApi.Models;

namespace Japanese.API.Areas.Public.Controllers;

public class KanaController : PublicController
{
    public KanaController(IMediator mediator)
        : base(mediator)
    {
    }

    [HttpPost]
    [Route("kana-list")]
    [ProducesResponseType(typeof(ExecResult<List<KanaDetailOutput>>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetList([FromBody] GetKanaListQuery query)
    {
        return await GetObjectResult(query);
    }

    [HttpPost]
    [Route("kana-types")]
    [ProducesResponseType(typeof(ExecResult<List<string>>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetTypes([FromBody] GetKanaTypesQuery query)
    {
        return await GetObjectResult(query);
    }

    [HttpPost]
    [Route("kana-details")]
    [ProducesResponseType(typeof(ExecResult<KanaDetailOutput>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetDetails([FromBody] GetKanaQuery query)
    {
        return await GetObjectResult(query);
    }
}