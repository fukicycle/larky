namespace Domain.Interfaces;

public interface IPersistencer<T> where T : struct
{
    Task SaveAsync(Enum key, T item);
    Task<T> GetAsync(Enum key);
}
