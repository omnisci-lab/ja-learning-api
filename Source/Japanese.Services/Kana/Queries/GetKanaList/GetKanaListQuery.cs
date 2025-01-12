using khothemegiatot.WebApi.CQRS.Cache;
using khothemegiatot.WebApi.Models;
using MediatR;

namespace Japanese.Services.Kana.Queries.GetKanaList;

public class GetKanaListQuery : IRequest<ExecResult<List<KanaDetailOutput>>>, ICacheableQuery
{
    public string? KanaType { get; set; }

    public string? CacheKey => $"kanalist_t:{KanaType}";

    public bool BypassCache { get; set; }
    public bool RefreshCache { get; set; }
}