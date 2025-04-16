using Domain.Entities;

namespace Infrastructure.DTO;

public sealed class WordDTO : DTO<WordDTO>
{
    public WordDTO(
        Guid id,
        string text,
        string partOfSpeech,
        string meaning,
        string exampleOfEnglish,
        string exampleOfJapanese)
    {
        Id = id;
        Text = text;
        PartOfSpeech = partOfSpeech;
        Meaning = meaning;
        ExampleOfEnglish = exampleOfEnglish;
        ExampleOfJapanese = exampleOfJapanese;
    }
    public Guid Id { get; }
    public string Text { get; }
    public string PartOfSpeech { get; }
    public string Meaning { get; }
    public string ExampleOfEnglish { get; }
    public string ExampleOfJapanese { get; set; }

    protected override bool EqualsCore(WordDTO other)
    {
        return Id == other.Id
            && Text == other.Text
            && PartOfSpeech == other.PartOfSpeech
            && Meaning == other.Meaning
            && ExampleOfEnglish == other.ExampleOfEnglish
            && ExampleOfJapanese == other.ExampleOfJapanese;
    }

    protected override int GetHashCodeCore()
    {
        return Id.GetHashCode();
    }
}
