using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Japanese.API.Areas.Public.Controllers;
using Japanese.Services.CommonWord.Queries;
using Japanese.Services.CommonWord.Queries.GetCommonWord;
using Japanese.Core.CommonModels;
using Japanese.Services.CommonWord.Queries.GetPagedCommonWords;
using khothemegiatot.WebApi.Models;

namespace Japanese.API.Controllers;

public class CommonWordController : PublicController
{
    public CommonWordController(IMediator mediator) : base(mediator)
    {
    }

    [HttpPost]
    [Route("common-word-paged")]
    [ProducesResponseType(typeof(ExecResult<PagedResult<CommonWordOutput>>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetList([FromBody] GetPagedCommonWordsQuery query)
    {
        return await GetObjectResult(query);
    }

    [HttpPost]
    [Route("common-word-details")]
    [ProducesResponseType(typeof(CommonWordOutput), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetDetails([FromBody] GetCommonWordQuery query)
    {
        return await GetObjectResult(query);
    }
}
