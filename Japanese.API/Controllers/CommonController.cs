using Japanese.API.Base;
using Japanese.Core.CommonModels;
using Japanese.Services.Common.Queries.ConvertToRomaji;
using Japanese.Services.Common.Queries.TextToSpeech;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Japanese.API.Controllers;

[Route("api/common")]
public class CommonController : ApiControllerBase
{
    public CommonController(IMediator mediator) 
        : base(mediator)
    {
    }

    [Route("convert-to-romaji")]
    [HttpGet]
    [ProducesResponseType(typeof(ExecResult<string>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> ConvertToRomaji([FromQuery] ConvertToRomajiQuery query)
    {
        return await GetObjectResult(query);
    }

    [Route("text-to-speech")]
    [HttpPost]
    [ProducesResponseType(typeof(Core.CommonModels.FileResult), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> ConvertToRomaji([FromBody] TextToSpeechQuery query)
    {
        return await GetFileResult(query);
    }
}
