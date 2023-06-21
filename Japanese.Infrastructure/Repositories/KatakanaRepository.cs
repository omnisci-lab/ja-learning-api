using Japanese.Application.Contracts.Presistence;
using Japanese.Domain.Entities;
using Japanese.Infrastructure.Base;
using Japanese.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Japanese.Infrastructure.Repositories;

public class KatakanaRepository : AsyncRepository<JapaneseDbContext, Katakana>, IKatakanaRepository
{

    internal KatakanaRepository(JapaneseDbContext context) 
        : base(context)
    {

    }

    public async Task<TOutput?> GetAsync<TOutput>(string? id, Expression<Func<Katakana, TOutput>> selector)
    {
        return await _context.Katakana.Where(s => s.Id == id)
            .Select(selector).SingleOrDefaultAsync();
    }

    public async Task<List<TOutput>> GetListAsync<TOutput>(Expression<Func<Katakana, TOutput>> selector, int count = 40)
    {
        return await _context.Katakana.Take(count)
            .Select(selector).ToListAsync();
    }

    protected override void ConfigureInclude()
    {
        throw new NotImplementedException();
    }


    protected override void ConfigureOrder()
    {
        throw new NotImplementedException();
    }

    protected override void ConfigureSearch()
    {
        throw new NotImplementedException();
    }
}
