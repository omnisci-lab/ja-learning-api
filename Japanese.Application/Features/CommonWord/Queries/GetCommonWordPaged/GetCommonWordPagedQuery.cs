using Japanese.Application.Cache;
using Japanese.Domain.Common;
using MediatR;

namespace Japanese.Application.Features.CommonWord.Queries.GetCommonWordPaged;

public class GetCommonWordPagedQuery : Pagination, IRequest<Pagination<CommonWordPagedOutput>>, ICacheableQuery
{
    public string? CacheKey => $"common-word-list:<<{Page}|{PageSize}|{OrderBy}|{OrderOptions}|{SearchBy}|{Keyword}";

    public bool Bypass { get; set; }

    public bool RefreshCache { get; set; }
}