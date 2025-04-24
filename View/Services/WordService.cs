using Domain.Enums;
using Domain.Interfaces;
using Infrastructure.DTO;

namespace View.Services;

public sealed class WordService
{
    private readonly IRepository<WordDTO, string> _wordRepository;
    public WordService(IServiceProvider provider)
    {
        _wordRepository = 
            provider.GetKeyedService<IRepository<WordDTO, string>>(nameof(FirebaseScheme.Words))
            ?? throw new NotSupportedException($"Specified service is not available. {nameof(FirebaseScheme.Words)}");
    }

    public async Task<IEnumerable<WordDTO>> GetWordsAsync()
    {
        var results = await _wordRepository.GetItemsAsync();
        return results.OrderBy(a => a.Level).ThenBy(a => a.Text);
    }

    public async Task<IEnumerable<WordDTO>> GetWordsAsync(int level)
    {
        var results = await _wordRepository.GetItemsAsync();
        return results.Where(a => a.Level == level).OrderBy(a => a.Text);
    }
}
