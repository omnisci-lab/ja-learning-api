using Japanese.Core.CommonModels;
using Japanese.Services.Cache;
using MediatR;

namespace Japanese.Services.KanjiRadical.Queries.GetKRadical;

public class GetKRadicalQuery : IRequest<ExecResult<KRadicalDetailOutput>>, ICacheableQuery
{
    public string? Character { get; set; }

    public string? CacheKey => $"kradical_{Character}";

    public bool BypassCache { get; set; }
    public bool RefreshCache { get; set; }
}
