using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Japanese.Services.Dictionary.Queries;
using Japanese.Services.Dictionary.Queries.GetDictionary;
using khothemegiatot.WebApi.Models;

namespace Japanese.API.Controllers;

public class DictionaryController : GeneralController
{
    public DictionaryController(IMediator mediator)
        : base(mediator)
    {
    }

    [HttpPost]
    [Route("dictionary-details")]
    [ProducesResponseType(typeof(ExecResult<DictionaryOutput>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetDetails([FromBody] GetDictionaryQuery query)
    {
        return await GetObjectResult(query);
    }
}
