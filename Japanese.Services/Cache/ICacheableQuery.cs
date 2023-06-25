namespace Japanese.Services.Cache;

public interface ICacheableQuery
{
    string? CacheKey { get; }
    bool Bypass { get; set; }
    bool RefreshCache { get; set; }
}