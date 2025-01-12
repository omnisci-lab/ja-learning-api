using Japanese.Core.CommonModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Japanese.Services.Dictionary.Queries;
using Japanese.Services.Dictionary.Queries.GetDictionary;
using khothemegiatot.WebApi.Models;

namespace Japanese.API.Areas.Admin.Controllers;

public class DictionaryAdmController : AdminController
{
    public DictionaryAdmController(IMediator mediator) 
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
