using Blazored.LocalStorage;
using Domain.Interfaces;

namespace Infrastructure.LocalStorage;

public sealed class LocalStorageService<T> : IPersistencer<T> where T : struct
{
    private readonly ILocalStorageService _localStorageService;
    public LocalStorageService(ILocalStorageService localStorageService)
    {
        _localStorageService = localStorageService;
    }

    public async Task<T> GetAsync(string key)
    {
        return await _localStorageService.GetItemAsync<T>(key);
    }

    public async Task SaveAsync(string key, T item)
    {
        await _localStorageService.SetItemAsync(key, item);
    }
}