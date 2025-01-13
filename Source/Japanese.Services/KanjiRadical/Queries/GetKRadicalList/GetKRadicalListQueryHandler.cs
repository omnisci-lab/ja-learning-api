using khothemegiatot.WebApi.Models;
using MediatR;

namespace Japanese.Services.KanjiRadical.Queries.GetKRadicalList;

public class GetKRadicalListQueryHandler : IRequestHandler<GetKRadicalListQuery, ExecResult<List<KRadicalDetailOutput>>>
{
    public Task<ExecResult<List<KRadicalDetailOutput>>> Handle(GetKRadicalListQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}