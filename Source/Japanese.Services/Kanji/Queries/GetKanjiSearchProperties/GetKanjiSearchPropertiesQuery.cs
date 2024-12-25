using Japanese.Core.CommonModels;
using MediatR;

namespace Japanese.Services.Kanji.Queries.GetSearchProperties;

public class GetKanjiSearchPropertiesQuery : IRequest<ExecResult<List<string>>>
{
}