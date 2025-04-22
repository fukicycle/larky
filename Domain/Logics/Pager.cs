namespace Domain.Logics;

public sealed class Pager<T>
{
    private readonly List<T> _items;
    public Pager(IEnumerable<T> items)
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

    public void Next()
    {
        CurrentIndex++;
        CurrentValue = _items[CurrentIndex];
    }

    public bool CanGoPrev()
    {
        return CurrentIndex > 0;
    }

    public void Prev()
    {
        CurrentIndex--;
        CurrentValue = _items[CurrentIndex];
    }

    public void Move(int index)
    {
        if(index >= _items.Count)
        {
            return;
        }
        CurrentIndex = index;
        CurrentValue = _items[CurrentIndex];
    }
}
