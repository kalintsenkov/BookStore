namespace BookStore.Application.Common.Contracts;

using System.Threading.Tasks;

public interface IMemoryDatabase
{
    Task Increment(string key);

    Task<TValue> Get<TValue>(string key);

    Task HashIncrement(string key, string hashField);

    Task<TValue> HashGet<TValue>(string key, string hashField);
}