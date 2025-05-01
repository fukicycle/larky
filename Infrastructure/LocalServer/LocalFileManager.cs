using System.Net.Http.Json;
using Domain.Interfaces;

namespace Infrastructure.LocalServer;

public sealed class LocalFileManager : ILocalFileManager
{
    private readonly HttpClient _httpClient;
    public LocalFileManager(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    public async Task<T> GetItem<T>(string path)
    {
        var result = await _httpClient.GetFromJsonAsync<T>(path);
        if (result == null)
        {
            throw new ArgumentException("No such resource.");
        }
        return result;
    }
}
