using Nest;
using NRedisStack;
using NRedisStack.RedisStackCommands;
using StackExchange.Redis;
using System.Text.Json;

namespace Japanese.Redis;

public class RedisHandler<TModel> where TModel : class, new()
{
    private readonly IConnectionMultiplexer _connectionMultiplexer;
    private readonly IDatabase _database;

    public RedisHandler(IConnectionMultiplexer connectionMultiplexer)
    {
        _connectionMultiplexer = connectionMultiplexer;
        _database = _connectionMultiplexer.GetDatabase();
    }

    public async Task Add(string key, TModel value)
    {
        try
        {
            _database.StringSet(key, JsonSerializer.Serialize<TModel>(value));

            //JsonCommands jsonCommands = _database.JSON();
            //jsonCommands.Set(key, "$", new { a = 'a', b= "b" });
        }
        catch(Exception e)
        {

        }
        
    }


}
