using Blazored.LocalStorage;
using Domain.Enums;
using Domain.Interfaces;
using Domain.Logics;
using Infrastructure.DTO;
using Infrastructure.LocalStorage;

namespace View.Services;

public sealed class UserService
{
    private readonly IRepository<UserDTO, string> _usersRepository;
    private readonly IPersistencer<PersistentSettingContainer> _persistencer;
    private PersistentSettingContainer _persistentSettingContainer;
    public UserService(IServiceProvider provider, ILocalStorageService localStorageService)
    {
        _usersRepository = provider.GetKeyedService<IRepository<UserDTO, string>>(nameof(FirebaseScheme.Users))
        ?? throw new NotSupportedException($"Specified service is not available. {nameof(FirebaseScheme.Users)}");
        _persistencer = new LocalStorageService<PersistentSettingContainer>(localStorageService);
    }

    public async Task InitializeAsync()
    {
        _persistentSettingContainer = await _persistencer.GetAsync(PersistentType.Setting);
    }

    public async Task<Guid> CreateAsync()
    {
        var nickname = Nickname.Get();
        var id = Guid.NewGuid();
        var userDTO = new UserDTO(id, nickname, null, 1, null, null);
        await _usersRepository.UpdateItemAsync(id, userDTO);
        _persistentSettingContainer.Id = id;
        await _persistencer.SaveAsync(PersistentType.Setting, _persistentSettingContainer);
        return id;
    }

    public async Task<UserDTO?> GetAsync()
    {
        Guid? id = _persistentSettingContainer.Id;
        if (id == null)
        {
            return null;
        }
        var user = await _usersRepository.GetItemAsync(id.Value);
        return user;
    }
}
