using Japanese.Core.CommonModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Japanese.Services.Kanji.Commands.CreateAndUpdateKanji;
using Japanese.Services.Kanji.Queries.GetKanji;
using Japanese.Services.Kanji.Queries.GetKanjiFilters;
using Japanese.Services.Kanji.Queries.GetPagedKanji;
using Japanese.Services.Kanji.Queries.GetSearchProperties;
using Japanese.Services.Kanji.Queries;

namespace Japanese.API.Areas.Admin.Controllers;

public class KanjiAdmController : AdminController
{
    public KanjiAdmController(IMediator mediator) : base(mediator)
    {
    }

    [HttpPost]
    [Route("kanji-paged")]
    [ProducesResponseType(typeof(ExecResult<PagedResult<KanjiDetailOutput>>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetPaged([FromBody] GetPagedKanjiQuery query)
    {
        return await GetObjectResult(query);
    }

    [HttpPost]
    [Route("kanji-details")]
    [ProducesResponseType(typeof(ExecResult<KanjiDetailOutput>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetDetails([FromBody] GetKanjiQuery query)
    {
        return await GetObjectResult(query);
    }

    [HttpPost]
    [Route("kanji-filters")]
    [ProducesResponseType(typeof(ExecResult<List<string>>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetFilters([FromBody] GetKanjiFiltersQuery query)
    {
        return await GetObjectResult(query);
    }

    [HttpPost]
    [Route("kanji-search-properties")]
    [ProducesResponseType(typeof(ExecResult<List<string>>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetSearchProperties([FromBody] GetKanjiSearchPropertiesQuery query)
    {
        return await GetObjectResult(query);
    }

    [HttpPost]
    [Route("kanji-create-and-update")]
    [ProducesResponseType(typeof(ExecResult), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> CreateAndUpdate([FromBody] CreateAndUpdateKanjiCommand command)
    {
        return await GetObjectResult(command);
    }
}