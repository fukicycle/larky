using Domain.Entities;

namespace Infrastructure.DTO;

public sealed class RankingDTO : DTO<RankingDTO>
{
    public RankingDTO(
        Dictionary<Guid, int>? daily,
        Dictionary<Guid, int>? monthly)
    {
        if (daily == null)
        {
            daily = new Dictionary<Guid, int>();
        }
        Daily = daily;
        if (monthly == null)
        {
            monthly = new Dictionary<Guid, int>();
        }
        Monthly = monthly;
    }
    public Dictionary<Guid, int> Daily { get; }
    public Dictionary<Guid, int> Monthly { get; }

    protected override bool EqualsCore(RankingDTO other)
    {
        return Daily.SequenceEqual(other.Daily)
            && Monthly.SequenceEqual(other.Monthly);
    }

    protected override int GetHashCodeCore()
    {
        return Daily.Count.GetHashCode() ^ Monthly.Count.GetHashCode();
    }
}
