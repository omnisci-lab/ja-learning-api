using Japanese.Core.CommonModels;
using khothemegiatot.WebApi.Models;
using MediatR;

namespace Japanese.Services.Kana.Queries.GetKanaTypes;

public class GetKanaTypesQuery : IRequest<ExecResult<List<string>>>
{
}