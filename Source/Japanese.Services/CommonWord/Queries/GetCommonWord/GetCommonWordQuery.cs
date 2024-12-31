using Japanese.Core.CommonModels;
using Japanese.Services.Cache;
using MediatR;

namespace Japanese.Services.CommonWord.Queries.GetCommonWord;

public class GetCommonWordQuery : IRequest<ExecResult<CommonWordOutput>>, ICacheableQuery
{
    public string? WordId { get; set; }

    public string? CacheKey => $"common-word-{WordId}";

    public bool BypassCache { get; set; }
    public bool RefreshCache { get; set; }
}
