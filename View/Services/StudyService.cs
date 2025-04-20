using Domain.Enums;
using Domain.Interfaces;
using Infrastructure.DTO;
using Microsoft.AspNetCore.Components;

namespace View.Services;

public sealed class StudyService
{
    private IRepository<WordDTO> _wordRepository;

    private IEnumerable<WordDTO> _words = Enumerable.Empty<WordDTO>();
    public StudyService(IServiceProvider services)
    {
        _wordRepository = services.GetKeyedService<IRepository<WordDTO>>(nameof(FirebaseScheme.Words))!;
    }
    public List<WordDTO> WordsPerOneTime { get; private set; } = new List<WordDTO>();
    private int _index = 0;
    private int _total = 0;
    private const int NUMBER_OF_WORDS = 10;

    public async Task InitializeAsync()
    {
        _words = await _wordRepository.GetItemsAsync();
        _total = (int)Math.Floor(_words.Count() * 1.0 / NUMBER_OF_WORDS);
        WordsPerOneTime = _words.Skip(0).Take(NUMBER_OF_WORDS).ToList();
        _index = 0;
    }

    public bool CanGoNext()
    {
        return _index < _total;
    }

    public void Next()
    {
        _index++;
        WordsPerOneTime = _words.Skip(_index * NUMBER_OF_WORDS).Take(NUMBER_OF_WORDS).ToList();
    }

    public bool CanGoPrev()
    {
        return _index > 0;
    }

    public void Prev()
    {
        _index--;
        WordsPerOneTime = _words.Skip(_index * NUMBER_OF_WORDS).Take(NUMBER_OF_WORDS).ToList();
    }
}
