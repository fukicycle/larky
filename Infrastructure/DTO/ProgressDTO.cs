using Domain.Entities;

namespace Infrastructure.DTO;

public sealed class ProgressDTO : DTO<ProgressDTO, DateTime>
{
    public ProgressDTO(
        DateTime dateTime, 
        bool isCorrect)
    {
        DateTime = dateTime;
        IsCorrect = isCorrect;
        FirstOrderKey = dateTime;
    }
    public DateTime DateTime { get; }
    public bool IsCorrect { get; }

    protected override bool EqualsCore(ProgressDTO other)
    {
        return DateTime == other.DateTime
             && IsCorrect == other.IsCorrect;
    }

    protected override int GetHashCodeCore()
    {
        return DateTime.GetHashCode();
    }
}
