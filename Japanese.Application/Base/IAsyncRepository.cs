using Japanese.Domain.Common;
using System.Linq.Expressions;

namespace Japanese.Application.Base;

public interface IAsyncRepository<TEntity> where TEntity : EntityBase
{
    Task<Pagination<TOutput>> GetPagedAsync<TOutput>(Pagination pagination, Expression<Func<TEntity, TOutput>> selector) where TOutput : class;
    Task<List<TOutput>> GetListAsync<TOutput>(int count, Expression<Func<TEntity, TOutput>> selector) where TOutput : class;
    Task<TOutput?> GetByPkAsync<TOutput>(Dictionary<string, object?> ids, Expression<Func<TEntity, TOutput>> selector) where TOutput : class;
    Task<ExecResult> AddAsync<TInput>(TInput entity, Action<TInput, TEntity> mapper) where TInput : class;
    Task<ExecResult> UpdateAsync<TInput>(object?[] keys, TInput input, Action<TInput, TEntity> mapper) where TInput : class;
    Task<ExecResult> BatchDeleteAsync(params object?[] ids);
    Task<ExecResult> ForceDeleteAsync(params object?[] ids);
}