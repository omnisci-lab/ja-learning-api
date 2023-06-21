using Japanese.Domain.Common;
using Microsoft.EntityFrameworkCore;
using Japanese.Application.Base;
using System.Text;
using System.Linq.Dynamic.Core;

namespace Japanese.Infrastructure.Base;

public abstract class Repository<TContext, TEntity> 
    : RepositoryBase<TContext, TEntity>, IRepository<TEntity>
    where TContext : DbContext
    where TEntity : EntityBase
{
    public Repository(TContext context)
        : base(context)
    {

    }

    public Repository(TContext context, DbSet<TEntity> dbSet)
        : base(context, dbSet)
    {

    }

    public Pagination<TOutput> GetPaged<TOutput>(Pagination pagination, System.Linq.Expressions.Expression<Func<TEntity, TOutput>> selector) where TOutput : class
    {
        throw new NotImplementedException();
    }

    public List<TOutput> GetList<TOutput>(int count, System.Linq.Expressions.Expression<Func<TEntity, TOutput>> selector) where TOutput : class
    {
        return _queryable.Where(x => x.IsDeleted == false).Take(count)
            .Select(selector).ToList();
    }

    public TOutput? GetByPk<TOutput>(Dictionary<string, object?> ids, System.Linq.Expressions.Expression<Func<TEntity, TOutput>> selector) where TOutput : class
    {
        StringBuilder expStrBuilder = new StringBuilder("x => ");
        bool first = true;
        foreach (KeyValuePair<string, object?> pair in ids)
        {
            if (!first)
                expStrBuilder.Append(" && ");

            if (pair.Value is string)
                expStrBuilder.Append($"x.{pair.Key} == \"{pair.Value}\"");
            else if (pair.Value is int || pair.Value is long)
                expStrBuilder.Append($"x.{pair.Key} == {pair.Value}");
            else
                throw new NotSupportedException();

            first = false;
        }

        return _queryable.Where(x => x.IsDeleted == false).Where(expStrBuilder.ToString())
            .Select(selector).SingleOrDefault();
    }

    public ExecResult Add<TInput>(TInput input, Action<TInput, TEntity> mapper) where TInput : class
    {
        TEntity entity = Activator.CreateInstance<TEntity>();
        mapper(input, entity);
        _dbSet.Add(entity);

        _context.SaveChanges();

        return new ExecResult { Status = ExecStatus.Success };
    }

    public ExecResult Update<TInput>(object?[] keys, TInput input, Action<TInput, TEntity> mapper) where TInput : class
    {
        TEntity? entity = _dbSet.Find(keys);
        if (entity is null)
            throw new NullReferenceException();

        mapper(input, entity);
        _dbSet.Add(entity);
        _context.SaveChanges();

        return new ExecResult { Status = ExecStatus.Success };
    }

    public ExecResult BatchDelete(params object?[] ids)
    {
        TEntity? entity = _dbSet.Find(ids);
        if (entity is null)
            return new ExecResult { Status = ExecStatus.NotFound };

        entity.IsDeleted = true;
        _context.SaveChanges();

        return new ExecResult { Status = ExecStatus.Success };
    }

    public ExecResult ForceDelete(params object?[] ids)
    {
        TEntity? entity = _dbSet.Find(ids);
        if (entity is null)
            return new ExecResult { Status = ExecStatus.NotFound };

        _dbSet.Remove(entity);
        _context.SaveChanges();

        return new ExecResult { Status = ExecStatus.Success };
    }
}
