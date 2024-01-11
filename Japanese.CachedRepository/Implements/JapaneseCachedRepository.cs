using Japanese.CachedRepository.Interfaces;
using Redis.OM;

namespace Japanese.CachedRepository.Implements;

public class JapaneseCachedRepository : IJapaneseCachedRepository
{
    private readonly RedisConnectionProvider _provider;

    public JapaneseCachedRepository(RedisConnectionProvider provider)
    {
        _provider = provider;
    }

    public IKanjidic2CachedRepository Kanjidic2CachedRepositoty => new Kanjidic2CachedRepository(_provider);
}
