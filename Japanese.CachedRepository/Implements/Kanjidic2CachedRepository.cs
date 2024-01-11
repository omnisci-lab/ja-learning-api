using Japanese.CachedRepository.Interfaces;
using Japanese.Core.CommonModels;
using Japanese.Models;
using Redis.OM;
using Redis.OM.Searching;
using System;

namespace Japanese.CachedRepository.Implements;

public class Kanjidic2CachedRepository : IKanjidic2CachedRepository
{
    private readonly RedisConnectionProvider _provider;
    private readonly RedisCollection<Kanjidic2Model> _kanjidic2;

    internal Kanjidic2CachedRepository(RedisConnectionProvider provider)
    {
        _provider = provider;
        _kanjidic2 = (RedisCollection<Kanjidic2Model>)provider.RedisCollection<Kanjidic2Model>();
    }

    public async Task<PagedResult<Kanjidic2Model>> GetPaginatedAsync(Pagination pagination)
    {
        PagedResult<Kanjidic2Model> pagedResult = new PagedResult<Kanjidic2Model>();
        pagedResult.Items = _kanjidic2.Skip((pagination.Page - 1) * pagination.PageSize)
            .Take(pagination.PageSize).ToList();

        var totalPages = (int)Math.Ceiling(_kanjidic2.Count() / (double)pagination.PageSize);

        return pagedResult;
    }
}