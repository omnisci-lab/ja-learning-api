using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Japanese.Services.CommonWord.Queries;
using Japanese.Services.CommonWord.Queries.GetCommonWord;
using Japanese.Services.CommonWord.Queries.GetPagedCommonWords;
using Japanese.Services.CommonWord.Commands.DeleteCommonWord;
using khothemegiatot.WebApi.Models;

namespace Japanese.API.Areas.Admin.Controllers;

public class CommonWordAdmController : AdminController
{
    public CommonWordAdmController(IMediator mediator) 
        : base(mediator)
    {
    }

    [HttpPost]
    [Route("common-word-paged")]
    [ProducesResponseType(typeof(ExecResult<PagedResult<CommonWordOutput>>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetPaged([FromBody] GetPagedCommonWordsQuery query)
    {
        return await GetObjectResult(query);
    }

    [HttpPost]
    [Route("common-word-details")]
    [ProducesResponseType(typeof(ExecResult<CommonWordOutput>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> Details([FromBody] GetCommonWordQuery query)
    {
        return await GetObjectResult(query);
    }

    [HttpPost]
    [Route("common-word-delete")]
    [ProducesResponseType(typeof(ExecResult), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> Delete([FromBody] DeleteCommonWordCommand command)
    {
        return await GetObjectResult(command);
    }
}
