using Japanese.Core.CommonModels;
using MediatR;

namespace Japanese.Services.KanjiRadical.Queries.GetKRadical;

public class GetKRadicalQuery : IRequest<ExecResult<KRadicalDetailOutput>>
{

}
