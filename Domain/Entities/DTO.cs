namespace Domain.Entities;

public abstract class DTO<TItem, TKey> where TItem : class
{
    public TKey? FirstOrderKey { get; protected set; }
    public override bool Equals(object? obj)
    {
        var vo = obj as TItem;
        if (vo == null)
        {
            return false;
        }
        return EqualsCore(vo);
    }

    public static bool operator ==(DTO<TItem, TKey>? vo1, DTO<TItem, TKey>? vo2)
    {
        return Equals(vo1, vo2);
    }

    public static bool operator !=(DTO<TItem, TKey>? vo1, DTO<TItem, TKey>? vo2)
    {
        return !Equals(vo1, vo2);
    }

    protected abstract bool EqualsCore(TItem other);
    protected abstract int GetHashCodeCore();

    public override int GetHashCode()
    {
        return GetHashCodeCore();
    }
}
