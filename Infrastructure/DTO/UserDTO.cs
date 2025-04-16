using Domain.Entities;

namespace Infrastructure.DTO;

public sealed class UserDTO : DTO<UserDTO>
{
    public UserDTO(
        Guid id,
        string name,
        string? email,
        Dictionary<Guid, ProgressDTO>? progresses,
        Dictionary<Guid, BadgeDTO>? badges)
    {
        Id = id;
        Name = name;
        Email = email;
        if (progresses == null)
        {
            progresses = new Dictionary<Guid, ProgressDTO>();
        }
        Progresses = progresses;
        if (badges == null)
        {
            badges = new Dictionary<Guid, BadgeDTO>();
        }
        Badges = badges;
    }
    public Guid Id { get; }
    public string Name { get; }
    public string? Email { get; }
    public Dictionary<Guid, ProgressDTO> Progresses { get; }
    public Dictionary<Guid, BadgeDTO> Badges { get; }

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
