using Japanese.Core.CommonModels;
using MediatR;

namespace Japanese.Services.Kana.Queries.GetKanaTypes;

public class GetKanaTypesQuery : IRequest<ExecResult<List<string>>>
{
}