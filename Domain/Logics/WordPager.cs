using Domain.Interfaces;

namespace Domain.Logics;

public sealed class WordPager<WordDTO> : IPager<WordDTO>
{
    private readonly List<WordDTO> _items;
    public WordPager(IEnumerable<WordDTO> items)
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
    public WordDTO CurrentValue { get; private set; }

    public bool CanGoNext()
    {
        return CurrentIndex < Count - 1;
    }

    public void GoNext()
    {
        CurrentIndex++;
        CurrentValue = _items[CurrentIndex];
    }

    public bool CanGoPrevious()
    {
        return CurrentIndex > 0;
    }

    public void GoPrevious()
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
