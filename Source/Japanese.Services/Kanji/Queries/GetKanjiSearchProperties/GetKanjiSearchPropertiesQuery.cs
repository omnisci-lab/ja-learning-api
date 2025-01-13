using khothemegiatot.WebApi.Models;
using MediatR;

namespace Japanese.Services.Kanji.Queries.GetSearchProperties;

public class GetKanjiSearchPropertiesQuery : IRequest<ExecResult<List<string>>>
{
}