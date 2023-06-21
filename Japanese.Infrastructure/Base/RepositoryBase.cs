using Japanese.Domain.Common;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Japanese.Infrastructure.Base;

public abstract class RepositoryBase<TContext, TEntity>
    where TContext : DbContext
    where TEntity : EntityBase
{
    public Search<TEntity> Search { get; } = new();
    public Order<TEntity> Order { get; } = new();

    protected readonly TContext _context;
    protected readonly DbSet<TEntity> _dbSet;
    protected IQueryable<TEntity> _queryable;

public RepositoryBase(TContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _dbSet = _context.Set<TEntity>();
        _queryable = _dbSet.AsQueryable();

        ConfigureSearch();
        ConfigureOrder();
    }

    public RepositoryBase(TContext context, DbSet<TEntity> dbSet)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _dbSet = dbSet ?? throw new ArgumentNullException(nameof(dbSet));
        _queryable = _dbSet.AsQueryable();

        ConfigureSearch();
        ConfigureOrder();
    }

    protected void Include<TProperty>(Expression<Func<TEntity, TProperty?>> navigationPropertyPath)
        where TProperty : class
    {
        _queryable = _queryable.Include(navigationPropertyPath);
    }

    protected abstract void ConfigureInclude();
    protected abstract void ConfigureSearch();
    protected abstract void ConfigureOrder();
}