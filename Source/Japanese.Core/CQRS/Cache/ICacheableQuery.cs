namespace Japanese.Services.Cache;

public interface ICacheableQuery
{
    string? CacheKey { get; }
    bool BypassCache { get; set; }
    bool RefreshCache { get; set; }
}