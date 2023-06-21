using Japanese.Application.Base;
using Japanese.Domain.Entities;
using System.Linq.Expressions;

namespace Japanese.Application.Contracts.Presistence;

public interface IKatakanaRepository : IAsyncRepository<Katakana>
{
    Task<List<TOutput>> GetListAsync<TOutput>(Expression<Func<Katakana, TOutput>> selector, int count = 40);
    Task<TOutput?> GetAsync<TOutput>(string? id, Expression<Func<Katakana, TOutput>> selector);
}
