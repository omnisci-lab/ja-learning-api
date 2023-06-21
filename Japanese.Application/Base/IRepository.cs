using Japanese.Domain.Common;
using System.Linq.Expressions;

namespace Japanese.Application.Base;

public interface IRepository<TEntity> 
    where TEntity : EntityBase
{
    Pagination<TOutput> GetPaged<TOutput>(Pagination pagination, Expression<Func<TEntity, TOutput>> selector) where TOutput : class;
    List<TOutput> GetList<TOutput>(int count, Expression<Func<TEntity, TOutput>> selector) where TOutput : class;
    TOutput? GetByPk<TOutput>(Dictionary<string, object?> ids, Expression<Func<TEntity, TOutput>> selector) where TOutput : class;
    ExecResult Add<TInput>(TInput entity, Action<TInput, TEntity> mapper) where TInput : class;
    ExecResult Update<TInput>(object?[] keys, TInput input, Action<TInput, TEntity> mapper) where TInput : class;
    ExecResult BatchDelete(params object?[] ids);
    ExecResult ForceDelete(params object?[] ids);
}