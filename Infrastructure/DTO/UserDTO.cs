using Domain.Entities;

namespace Infrastructure.DTO;

public sealed class UserDTO : DTO<UserDTO, string>
{
    public UserDTO(
        Guid id,
        string name,
        string? email,
        int unlockLevel,
        Dictionary<Guid, ProgressDTO>? progresses,
        Dictionary<Guid, CollectedBadgeDTO>? badges)
    {
        Id = id;
        Name = name;
        Email = email;
        UnlockLevel = unlockLevel;
        if (progresses == null)
        {
            progresses = new Dictionary<Guid, ProgressDTO>();
        }
        Progresses = progresses;
        if (badges == null)
        {
            badges = new Dictionary<Guid, CollectedBadgeDTO>();
        }
        Badges = badges;
        FirstOrderKey = name;
    }
    public Guid Id { get; }
    public string Name { get; }
    public string? Email { get; }
    public int UnlockLevel { get; }
    public Dictionary<Guid, ProgressDTO> Progresses { get; }
    public Dictionary<Guid, CollectedBadgeDTO> Badges { get; }

    protected override bool EqualsCore(UserDTO other)
    {
        return Id == other.Id
            && Name == other.Name
            && Email == other.Email;
    }

    protected override int GetHashCodeCore()
    {
        return Id.GetHashCode();
    }
}
