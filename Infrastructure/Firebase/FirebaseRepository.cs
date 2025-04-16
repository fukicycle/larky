using System.Reflection;
using Domain.Entities;
using Domain.Enums;
using Domain.Interfaces;
using Firebase.Database;
using Firebase.Database.Query;

namespace Infrastructure.Firebase;

public sealed class FirebaseRepository<T> : IRepository<T> where T : DTO<T>
{
    private const string URI = @"https://larky-ebf2c-default-rtdb.asia-southeast1.firebasedatabase.app/";
    private IEnumerable<PropertyInfo> _properties;
    private FirebaseClient _client;
    private string _scheme;
    public FirebaseRepository(FirebaseScheme scheme)
    {
        _scheme = nameof(scheme);
        _properties = typeof(T).GetProperties();
        _client = new FirebaseClient(URI, new FirebaseOptions
        {
            AuthTokenAsyncFactory = () => Task.FromResult("")
        });
    }

    public async Task DeleteItemAsync(Guid id)
    {
        await _client.Child(_scheme).Child(id.ToString()).DeleteAsync();
    }

    public async Task<T> GetItemAsync(Guid id)
    {
        return await _client.Child(_scheme).Child(id.ToString()).OnceSingleAsync<T>();
    }

    public async Task<IEnumerable<T>> GetItemsAsync()
    {
        var results = await _client.Child(_scheme).OnceAsync<T>();
        return results.Select(a => a.Object);
    }

    public async Task<IEnumerable<TValue>> GetItemsValueAsync<TValue>(params string[] children)
    {
        var childQuery = _client.Child(_scheme);
        var query = AppendChild(childQuery, children);
        var results = await query.OnceAsync<TValue>();
        return results.Select(a => a.Object);
    }

    public async Task<TValue> GetItemValueAsync<TValue>(params string[] children)
    {
        var childQuery = _client.Child(_scheme);
        var query = AppendChild(childQuery, children);
        return await query.OnceSingleAsync<TValue>();
    }

    public async Task UpdateItemAsync(Guid id, T item)
    {
        await _client.Child(_scheme).Child(id.ToString()).PutAsync(item);
    }

    public async Task UpdateItemAsync<TValue>(TValue value, params string[] children)
    {
        var childQuery = _client.Child(_scheme);
        var query = AppendChild(childQuery, children);
        await query.PutAsync(value);
    }

    private ChildQuery AppendChild(ChildQuery childQuery, params string[] children)
    {
        if (!children.All(a => _properties.Any(b => b.Name == a)))
        {
            throw new NotSupportedException($"Some child is not include. Type: {typeof(T).Name}");
        }
        var tmpChildQuery = childQuery;
        foreach (var child in children)
        {
            tmpChildQuery = tmpChildQuery.Child(child);
        }
        return tmpChildQuery;
    }
}
