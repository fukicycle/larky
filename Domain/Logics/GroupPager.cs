using Domain.Interfaces;

namespace Domain.Logics;

public sealed class GroupPager<T> : IPager<ItemPager<T>>
{
    private readonly List<T> _originalItems;
    private readonly List<ItemPager<T>> _groupItems;
    public GroupPager(IEnumerable<T> originalItems, int numberOfPerGroup)
    {
        _originalItems = originalItems.ToList();
        _groupItems = _originalItems.Chunk(numberOfPerGroup)
                                    .Select(a => new ItemPager<T>(a))
                                    .ToList();
        NumberOfPerGroup = numberOfPerGroup;
        Count = _groupItems.Count;
        CurrentValue = _groupItems[CurrentIndex];
    }

    public int NumberOfPerGroup { get; }
    public int Count { get; }

    public int CurrentIndex { get; private set; }

    public ItemPager<T> CurrentValue { get; private set; }

    public bool CanGoNext()
    {
        return CurrentIndex < Count - 1;
    }

    public void GoNext()
    {
        if (!CanGoNext())
        {
            return;
        }
        CurrentIndex++;
        CurrentValue = _groupItems[CurrentIndex];
    }

    public bool CanGoPrevious()
    {
        return CurrentIndex > 0;
    }

    public void GoPrevious()
    {
        if (!CanGoPrevious())
        {
            return;
        }
        CurrentIndex--;
        CurrentValue = _groupItems[CurrentIndex];
    }

    public bool Move(int index)
    {
        if (index >= _groupItems.Count || index < 0)
        {
            return false;
        }
        CurrentIndex = index;
        CurrentValue = _groupItems[CurrentIndex];
        return true;
    }
}
