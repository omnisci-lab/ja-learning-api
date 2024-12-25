using Japanese.Core.CommonModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Japanese.Services.KanjiRadical.Queries.GetKRadical;
using Japanese.Services.KanjiRadical.Queries;

namespace Japanese.API.Areas.Public.Controllers;

public class KRadicalController : PublicController
{
    public KRadicalController(IMediator mediator) : base(mediator)
    {
    }

    [HttpPost]
    [Route("kanji-radical-details")]
    [ProducesResponseType(typeof(ExecResult<KRadicalDetailOutput>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetDetails([FromBody] GetKRadicalQuery query)
    {
        return await GetObjectResult(query);
    }
}
