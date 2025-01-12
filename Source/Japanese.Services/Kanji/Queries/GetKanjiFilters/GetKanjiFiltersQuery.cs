using Japanese.Core.CommonModels;
using khothemegiatot.WebApi.Models;
using MediatR;

namespace Japanese.Services.Kanji.Queries.GetKanjiFilters;

public class GetKanjiFiltersQuery : IRequest<ExecResult<List<string>>>
{
}
