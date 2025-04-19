namespace Domain.Entities;

public abstract class DTO<T> where T : class
{
    public override bool Equals(object? obj)
    {
        var vo = obj as T;
        if (vo == null)
        {
            return false;
        }
        return EqualsCore(vo);
    }

    public static bool operator ==(DTO<T>? vo1, DTO<T>? vo2)
    {
        return Equals(vo1, vo2);
    }

    public static bool operator !=(DTO<T>? vo1, DTO<T>? vo2)
    {
        return !Equals(vo1, vo2);
    }

    protected abstract bool EqualsCore(T other);
    protected abstract int GetHashCodeCore();

    public override int GetHashCode()
    {
        return GetHashCodeCore();
    }
}
