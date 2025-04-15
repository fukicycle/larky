namespace Infrastructure.DTO;

public sealed class BadgeDTO
{
    public BadgeDTO(
        string name,
        string description,
        string iconPath)
    {
        Name = name;
        Description = description;
        IconPath = iconPath;
    }
    public string Name { get; }
    public string Description { get; }
    public string IconPath { get; }
}
