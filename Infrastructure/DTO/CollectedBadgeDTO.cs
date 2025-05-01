using Domain.Entities;

namespace Infrastructure.DTO;

public sealed class CollectedBadgeDTO : DTO<CollectedBadgeDTO, DateTime>
{
    public CollectedBadgeDTO(
        DateTime awardedDateTime,
        string iconPath,
        string name)
    {
        AwardedDateTime = awardedDateTime;
        IconPath = iconPath;
        Name = name;
        FirstOrderKey = AwardedDateTime;
    }
    public DateTime AwardedDateTime { get; }
    public string IconPath { get; }
    public string Name { get; }

    protected override bool EqualsCore(CollectedBadgeDTO other)
    {
        return other.Name == Name &&
            other.AwardedDateTime == AwardedDateTime;
    }

    protected override int GetHashCodeCore()
    {
        return Name.GetHashCode() ^ AwardedDateTime.GetHashCode();
    }
}
