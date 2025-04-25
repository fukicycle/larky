using Domain.Enums;
using Domain.Interfaces;
using Infrastructure.DTO;

namespace View.Services;

public sealed class WordService
{
    private readonly IRepository<WordDTO, string> _wordRepository;
    private readonly AppStateContainer _stateContainer;
    public WordService(IServiceProvider provider, AppStateContainer stateContainer)
    {
        _wordRepository =
            provider.GetKeyedService<IRepository<WordDTO, string>>(nameof(FirebaseScheme.Words))
            ?? throw new NotSupportedException($"Specified service is not available. {nameof(FirebaseScheme.Words)}");
        _stateContainer = stateContainer;
    }

    public async Task<IReadOnlyList<WordDTO>> GetWordsAsync(int level)
    {
        var results = await _wordRepository.GetItemsAsync();
        return results.Where(a => a.Level == level)
                      .OrderBy(a => a.Text)
                      .ToList();
    }

    public async Task<IReadOnlyList<WordDTO>> GetWordsAsync(int minLevel = 1, int maxLevel = 3)
    {
        var results = await _wordRepository.GetItemsAsync();
        return results.Where(a => a.Level >= minLevel && a.Level <= Math.Min(maxLevel, _stateContainer.CurrentLevel))
                      .OrderBy(a => a.Level)
                      .ThenBy(a => a.Text)
                      .ToList();
    }
}
