using Japanese.Core.CommonModels;
using Japanese.Services.KanjiRadical.Queries.GetKRadical;
using Japanese.Services.KanjiRadical.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Japanese.Services.KanjiRadical.Queries.GetKRadicalList;
using Japanese.Services.KanjiRadical.Commands.CreateAndUpdateKRadical;
using Japanese.Services.KanjiRadical.Commands.DeleteKRadical;

namespace Japanese.API.Areas.Admin.Controllers;

[Route("api/radical")]
[ApiController]
public class KRadicalAdmController : AdminController
{
    public KRadicalAdmController(IMediator mediator) 
        : base(mediator)
    {
    }

    [HttpPost]
    [Route("kanji-radical-list")]
    [ProducesResponseType(typeof(ExecResult<List<KRadicalDetailOutput>>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetList([FromBody] GetKRadicalListQuery query)
    {
        return await GetObjectResult(query);
    }


    [HttpPost]
    [Route("kanji-radical-details")]
    [ProducesResponseType(typeof(ExecResult<KRadicalDetailOutput>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetDetails([FromBody] GetKRadicalQuery query)
    {
        return await GetObjectResult(query);
    }

    [HttpPost]
    [Route("kanji-create-and-update")]
    [ProducesResponseType(typeof(ExecResult), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> CreateAndUpdate([FromBody] CreateAndUpdateKRadicalCommand query)
    {
        return await GetObjectResult(query);
    }

    [HttpPost]
    [Route("kanji-delete")]
    [ProducesResponseType(typeof(ExecResult), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> Delete([FromBody] DeleteKRadicalCommand query)
    {
        return await GetObjectResult(query);
    }
}