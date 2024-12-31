using Japanese.Core.CommonModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Japanese.Services.CommonWord.Queries;
using Japanese.Services.CommonWord.Queries.GetCommonWord;

namespace Japanese.API.Areas.Admin.Controllers;

public class CommonWordAdmController : AdminController
{
    public CommonWordAdmController(IMediator mediator) 
        : base(mediator)
    {
    }

    [HttpPost]
    [Route("common-word-details")]
    [ProducesResponseType(typeof(ExecResult<List<CommonWordOutput>>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetList([FromBody] GetCommonWordQuery query)
    {
        return await GetObjectResult(query);
    }
}
