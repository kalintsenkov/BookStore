namespace BookStore.Infrastructure.Common.Services;

using System.Threading.Tasks;
using Application.Common.Contracts;
using StackExchange.Redis;

internal class MemoryDatabase : IMemoryDatabase
{
    private readonly IConnectionMultiplexer connection;

    public MemoryDatabase(IConnectionMultiplexer connection)
        => this.connection = connection;

    public async Task Increment(string key)
    {
        var database = this.connection.GetDatabase();

        await database.StringIncrementAsync(key);
    }

    public async Task<TValue> Get<TValue>(string key)
    {
        var database = this.connection.GetDatabase();

        var value = await database.StringGetAsync(key);

        return (TValue)value.Box()!;
    }

    public async Task HashIncrement(string key, string hashField)
    {
        var database = this.connection.GetDatabase();

        await database.HashIncrementAsync(key, hashField);
    }

    public async Task<TValue> HashGet<TValue>(string key, string hashField)
    {
        var database = this.connection.GetDatabase();

        var value = await database.HashGetAsync(key, hashField);

        return (TValue)value.Box()!;
    }
}