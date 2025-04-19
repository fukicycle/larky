using Domain.Entities;

namespace Domain.Interfaces;

public interface IRepository<T> where T : DTO<T>
{
    Task DeleteItemAsync(Guid id);
    Task<T> GetItemAsync(Guid id);
    Task<IEnumerable<T>> GetItemsAsync();
    Task<IEnumerable<TValue>> GetItemsValueAsync<TValue>(params string[] children);
    Task<TValue> GetItemValueAsync<TValue>(params string[] children);
    Task UpdateItemAsync(Guid id, T item);
    Task UpdateItemAsync<TValue>(TValue value, params string[] children);
}
