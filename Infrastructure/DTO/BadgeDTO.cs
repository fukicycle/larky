using Domain.Entities;

namespace Infrastructure.DTO;

public sealed class BadgeDTO : DTO<BadgeDTO, string>
{
    public BadgeDTO(
        string name,
        string description,
        string iconPath)
    {
        Name = name;
        Description = description;
        IconPath = iconPath;
        FirstOrderKey = name;
    }
    public string Name { get; }
    public string Description { get; }
    public string IconPath { get; }

    protected override bool EqualsCore(BadgeDTO other)
    {
        return Name == other.Name
            && Description == other.Description
            && IconPath == other.IconPath;
    }

    protected override int GetHashCodeCore()
    {
        return Name.GetHashCode();
    }
}
