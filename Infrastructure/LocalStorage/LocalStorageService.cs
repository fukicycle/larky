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

    public async Task<T> GetAsync(Enum key)
    {
        return await _localStorageService.GetItemAsync<T>(key.ToString());
    }

    public async Task SaveAsync(Enum key, T item)
    {
        await _localStorageService.SetItemAsync(key.ToString(), item);
    }
}