namespace BookStore.Application.Common.Contracts;

using System.Collections.Generic;
using System.Threading.Tasks;

public interface IMemoryDatabase
{
    Task AddOrUpdate<TValue>(string key, TValue value);

    Task<TValue?> Get<TValue>(string key);

    Task Remove(string key);

    Task<List<TValue>> GetList<TValue>(string key);

    Task AddToList<TValue>(string key, TValue value);

    Task RemoveFromList<TValue>(string key, TValue value);
}