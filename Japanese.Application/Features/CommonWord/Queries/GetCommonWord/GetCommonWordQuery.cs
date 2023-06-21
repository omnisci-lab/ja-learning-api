using Japanese.Application.Cache;
using MediatR;

namespace Japanese.Application.Features.CommonWord.Queries.GetCommonWord;

public class GetCommonWordQuery : IRequest<CommonWordOutput>, ICacheableQuery
{
    public string? WordId { get; set; }

    public string? CacheKey => $"common-word:{WordId}";

    public bool Bypass { get; set; }

    public bool RefreshCache { get; set; }
}