using Japanese.Core.CommonModels;
using Japanese.Services.Cache;
using MediatR;

namespace Japanese.Services.Kana.Queries.GetKanaList;

public class GetKanaListQuery : IRequest<ExecResult<List<KanaDetailOutput>>>, ICacheableQuery
{
    public string? KanaType { get; set; }

    public string? CacheKey => $"hiragana_list";

    public bool BypassCache { get; set; }
    public bool RefreshCache { get; set; }
}