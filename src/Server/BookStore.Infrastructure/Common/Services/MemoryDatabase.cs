namespace BookStore.Infrastructure.Common.Services;

using System.Collections.Generic;
using System;
using System.Text.Json;
using System.Threading.Tasks;
using Application.Common.Contracts;
using StackExchange.Redis;

internal class MemoryDatabase : IMemoryDatabase
{
    private readonly IConnectionMultiplexer connection;

    public MemoryDatabase(IConnectionMultiplexer connection)
        => this.connection = connection;

    public async Task AddOrUpdate<TValue>(string key, TValue value)
    {
        var database = this.connection.GetDatabase();

        var json = JsonSerializer.Serialize(value);

        await database.StringSetAsync(key, json, TimeSpan.FromMinutes(30));
    }

    public async Task<TValue?> Get<TValue>(string key)
    {
        var database = this.connection.GetDatabase();

        if (!database.KeyExists(key))
        {
            return default;
        }

        var json = await database.StringGetAsync(key);

        var value = JsonSerializer.Deserialize<TValue>(json!);

        return value;
    }

    public async Task Remove(string key)
    {
        var database = this.connection.GetDatabase();

        await database.KeyDeleteAsync(key);
    }

    public async Task<List<TValue>> GetList<TValue>(string key)
    {
        var database = this.connection.GetDatabase();

        if (!database.KeyExists(key))
        {
            return new List<TValue>();
        }

        var json = await database.StringGetAsync(key);

        var value = JsonSerializer.Deserialize<List<TValue>>(json!);

        return value!;
    }

    public async Task AddToList<TValue>(string key, TValue value)
    {
        var database = this.connection.GetDatabase();

        var list = await this.GetList<TValue>(key);

        list.Add(value);

        var json = JsonSerializer.Serialize(list);

        await database.StringSetAsync(key, json);
    }

    public async Task RemoveFromList<TValue>(string key, TValue value)
    {
        var database = this.connection.GetDatabase();

        var list = await this.GetList<TValue>(key);

        list.Remove(value);

        var json = JsonSerializer.Serialize(list);

        await database.StringSetAsync(key, json);
    }
}