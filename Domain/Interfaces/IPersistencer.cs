namespace Domain.Interfaces;

public interface IPersistencer<T> where T : struct
{
    Task SaveAsync(string key, T item);
    Task<T> GetAsync(string key);
}
