using Japanese.Application.Base;
using Japanese.Domain.Common;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Text;

namespace Japanese.Infrastructure.Base;

public abstract class AsyncRepository<TContext, TEntity> 
    : RepositoryBase<TContext, TEntity>, IAsyncRepository<TEntity> 
    where TContext : DbContext
    where TEntity : EntityBase
{
    public AsyncRepository(TContext context)
        : base(context)
    {

    }

    public AsyncRepository(TContext context, DbSet<TEntity> dbSet)
        : base(context, dbSet)
    {

    }

    public async Task<Pagination<TOutput>> GetPagedAsync<TOutput>(Pagination pagination, Expression<Func<TEntity, TOutput>> selector) where TOutput : class
    {
        IQueryable<TEntity> queryable = _queryable.Where(x => x.IsDeleted == false);
        if (string.IsNullOrEmpty(pagination.SearchBy))
            queryable = queryable.Where(Search.Get("All", pagination.Keyword));
        else
            queryable = queryable.Where(Search.Get(pagination.SearchBy, pagination.Keyword));

        if (string.IsNullOrEmpty(pagination.OrderBy))
            queryable = queryable.OrderByDescending(x => x.CreatedBy);
        else if (pagination.OrderOptions == OrderOptions.ASC)
            queryable = queryable.OrderBy(Order.Get(pagination.OrderBy));
        else
            queryable = queryable.OrderByDescending(Order.Get(pagination.OrderBy));

        int n = (pagination.Page - 1) * pagination.PageSize;

        int totalItemCount = await queryable.CountAsync();
        IReadOnlyList<TOutput> items = await queryable.Skip(n).Take(pagination.PageSize)
            .Select(selector).ToListAsync();

        return pagination.WithData(items, totalItemCount);
    }

    public virtual async Task<List<TOutput>> GetListAsync<TOutput>(int count, Expression<Func<TEntity, TOutput>> selector) where TOutput : class
    {
        return await _queryable.Where(x => x.IsDeleted == false).Take(count)
            .Select(selector).ToListAsync();
    }

    public async Task<TOutput?> GetByPkAsync<TOutput>(Dictionary<string, object?> ids, Expression<Func<TEntity, TOutput>> selector) where TOutput : class
    {
        StringBuilder expStrBuilder = new StringBuilder("x => ");
        bool first = true;
        foreach(KeyValuePair<string, object?> pair in ids)
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

        return await _queryable.Where(x => x.IsDeleted == false).Where(expStrBuilder.ToString())
            .Select(selector).SingleOrDefaultAsync();
    }

    public virtual async Task<ExecResult> AddAsync<TInput>(TInput input, Action<TInput, TEntity> mapper) 
        where TInput : class
    { 
        TEntity entity = Activator.CreateInstance<TEntity>();
        mapper(input, entity);
        _dbSet.Add(entity);

        await _context.SaveChangesAsync();

        return new ExecResult { Status = ExecStatus.Success };
    }

    public virtual async Task<ExecResult> UpdateAsync<TInput>(object?[] keys, TInput input, Action<TInput, TEntity> mapper)
        where TInput : class
    {
        TEntity? entity = await _dbSet.FindAsync(keys);
        if (entity is null)
            throw new NullReferenceException();

        mapper(input, entity);
        await _context.SaveChangesAsync();

        return new ExecResult { Status = ExecStatus.Success };
    }

    public virtual async Task<ExecResult> BatchDeleteAsync(params object?[] ids)
    {
        TEntity? entity = await _dbSet.FindAsync(ids);
        if (entity is null)
            return new ExecResult { Status = ExecStatus.NotFound };

        entity.IsDeleted = true;
        await _context.SaveChangesAsync();

        return new ExecResult { Status = ExecStatus.Success };
    }

    public virtual async Task<ExecResult> ForceDeleteAsync(params object?[] ids)
    {
        TEntity? entity = await _dbSet.FindAsync(ids);
        if (entity is null)
            return new ExecResult { Status = ExecStatus.NotFound };

        _dbSet.Remove(entity);
        await _context.SaveChangesAsync();

        return new ExecResult { Status = ExecStatus.Success };
    }
}
