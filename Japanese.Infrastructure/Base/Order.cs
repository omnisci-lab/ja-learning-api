using System.Linq.Expressions;

namespace Japanese.Infrastructure.Base;

public class Order<TEntity>
{
    private Dictionary<string, Expression<Func<TEntity, object?>>> _dict;

    public Order()
    {
        _dict = new Dictionary<string, Expression<Func<TEntity, object?>>>();
    }

    public void Add(string key, Expression<Func<TEntity, object?>> order)
    {
        _dict.Add(key, order);
    }

    public Expression<Func<TEntity, object?>> Get(string key)
    {
        return _dict[key];
    }
}
