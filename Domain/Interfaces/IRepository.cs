using Domain.Entities;

namespace Domain.Interfaces;

public interface IRepository<TItem, TKey> where TItem : DTO<TItem, TKey>
{
    Task DeleteItemAsync(Guid id);
    Task<TItem> GetItemAsync(Guid id);
    Task<IEnumerable<TItem>> GetItemsAsync();
    Task<IEnumerable<TValue>> GetItemsValueAsync<TValue>(params string[] children);
    Task<TValue> GetItemValueAsync<TValue>(params string[] children);
    Task UpdateItemAsync(Guid id, TItem item);
    Task UpdateItemAsync<TValue>(TValue value, params string[] children);
}
