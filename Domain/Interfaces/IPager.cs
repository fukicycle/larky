namespace Domain.Interfaces;

public interface IPager<T>
{
    int Count { get; }
    int CurrentIndex { get; }
    T CurrentValue { get; }
    bool CanGoNext();
    bool CanGoPrevious();
    void GoNext();
    void GoPrevious();
    void Move(int index);
}
