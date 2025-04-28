namespace Domain.Interfaces;

public interface ILocalFileManager
{
    Task<T> GetItem<T>(string path);
}
