using Japanese.Domain.Common;
using System.Linq.Expressions;

namespace Japanese.Infrastructure.Base;

public class Search<TEntity> where TEntity : EntityBase
{
    private Dictionary<string, Func<TEntity?, string?, Expression<Func<TEntity, bool>>>> _dict;

    public Search()
    {
        _dict = new Dictionary<string, Func<TEntity?, string?, Expression<Func<TEntity, bool>>>>();
    }

    public void Add(string key, Func<TEntity?, string?, Expression<Func<TEntity, bool>>> predicate)
    {
        _dict.Add(key, predicate);
    }

    public Expression<Func<TEntity, bool>> Get(string key, string? searchKeyword)
    {
        var e = _dict[key]!(default(TEntity), searchKeyword);
        return e;
    }
}