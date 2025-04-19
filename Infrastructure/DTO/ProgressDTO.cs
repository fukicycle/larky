using Domain.Entities;

namespace Infrastructure.DTO;

public sealed class ProgressDTO : DTO<ProgressDTO>
{
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
