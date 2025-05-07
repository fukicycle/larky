using Domain.Interfaces;

namespace Domain.Logics;

public sealed class ItemPager<T> : IPager<T>
{
    private readonly List<T> _items;
    public ItemPager(IEnumerable<T> items)
    {
        if (!items.Any())
        {
            throw new ArgumentException("Provided items is empty!");
        }
        _items = items.ToList();
        Count = _items.Count;
        CurrentValue = _items[CurrentIndex];
    }

    public int Count { get; }
    public int CurrentIndex { get; private set; }
    public T CurrentValue { get; private set; }

    public bool CanGoNext()
    {
        return CurrentIndex < Count - 1;
    }

    public void GoNext()
    {
        if(!CanGoNext())
        {
            return;
        }
        CurrentIndex++;
        CurrentValue = _items[CurrentIndex];
    }

    public bool CanGoPrevious()
    {
        return CurrentIndex > 0;
    }

    public void GoPrevious()
    {
        if(!CanGoPrevious())
        {
            return;
        }
        CurrentIndex--;
        CurrentValue = _items[CurrentIndex];
    }

    public bool Move(int index)
    {
        if (index >= _items.Count || index < 0)
        {
            return false;
        }
        CurrentIndex = index;
        CurrentValue = _items[CurrentIndex];
        return true;
    }
}
