using Japanese.Core.CommonModels;
using Japanese.Services.Cache;
using MediatR;

namespace Japanese.Services.Kana.Queries.GetKana;

public class GetKanaQuery : IRequest<ExecResult<KanaDetailOutput?>>, ICacheableQuery
{
    public string? Character { get; set; }

    public string? CacheKey => $"kana_{Character}";

    public bool BypassCache { get; set; }
    public bool RefreshCache { get; set; }
}