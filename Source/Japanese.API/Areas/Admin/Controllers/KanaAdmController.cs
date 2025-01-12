using Japanese.Core.CommonModels;
using Japanese.Services.Kana.Commands.CreateAndUpdateKana;
using Japanese.Services.Kana.Commands.DeleteKana;
using Japanese.Services.Kana.Queries.GetKana;
using Japanese.Services.Kana.Queries.GetKanaList;
using Japanese.Services.Kana.Queries.GetKanaTypes;
using Japanese.Services.Kana.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using khothemegiatot.WebApi.Models;

namespace Japanese.API.Areas.Admin.Controllers;

public class KanaAdmController : AdminController
{
    public KanaAdmController(IMediator mediator) : base(mediator)
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

    [HttpPost]
    [Route("kana-create-and-update")]
    [ProducesResponseType(typeof(ExecResult), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> CreateAndUpdate([FromBody] CreateAndUpdateKanaCommand command)
    {
        return await GetObjectResult(command);
    }

    [HttpPost]
    [Route("kana-delete")]
    [ProducesResponseType(typeof(ExecResult), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> Delete([FromBody] DeleteKanaCommand command)
    {
        return await GetObjectResult(command);
    }
}
