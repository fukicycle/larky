using Domain.Interfaces;

namespace Domain.Logics;

public sealed class GroupPager<T> : IPager<ItemPager<T>>
{
    private readonly List<T> _originalItems;
    private readonly List<ItemPager<T>> _groupItems;
    public GroupPager(IEnumerable<T> originalItems, int numberOfPerGroup)
    {
        _originalItems = originalItems.ToList();
        int numberOfSplit = Convert.ToInt32(Math.Ceiling(_originalItems.Count * 1.0 / numberOfPerGroup));
        _groupItems = _originalItems.Select(item =>
                            new { Index = _originalItems.IndexOf(item), Item = item })
                                    .GroupBy(itemWithIndex => itemWithIndex.Index % numberOfSplit)
                                    .Select(groupingItem => new ItemPager<T>(groupingItem.Select(item => item.Item)))
                                    .ToList();
        NumberOfPerGroup = numberOfPerGroup;
        Count = Math.Min(_groupItems[CurrentIndex].Count, NumberOfPerGroup);
        CurrentValue = _groupItems[CurrentIndex];
    }

    public int NumberOfPerGroup { get; }
    public int Count { get; private set; }

    public int CurrentIndex { get; private set; }

    public ItemPager<T> CurrentValue { get; private set; }

    public bool CanGoNext()
    {
        return CurrentIndex < Count - 1;
    }

    public void GoNext()
    {
        CurrentIndex++;
        CurrentValue = _groupItems[CurrentIndex];
        Count = Math.Min(_groupItems[CurrentIndex].Count, NumberOfPerGroup);
    }

    public bool CanGoPrevious()
    {
        return CurrentIndex > 0;
    }

    public void GoPrevious()
    {
        CurrentIndex--;
        CurrentValue = _groupItems[CurrentIndex];
        Count = Math.Min(_groupItems[CurrentIndex].Count, NumberOfPerGroup);
    }

    public void Move(int index)
    {
        if(index >= _groupItems.Count)
        {
            return;
        }
        CurrentIndex = index;
        CurrentValue = _groupItems[CurrentIndex];
    }
}
