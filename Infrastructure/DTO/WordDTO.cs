using Domain.Entities;

namespace Infrastructure.DTO;

public sealed class WordDTO : DTO<WordDTO, string>
{
    public WordDTO(
        Guid id,
        string text,
        int level,
        string meaning,
        string exampleOfEnglish,
        string exampleOfJapanese)
    {
        Id = id;
        Text = text;
        Level = level;
        Meaning = meaning;
        ExampleOfEnglish = exampleOfEnglish;
        ExampleOfJapanese = exampleOfJapanese;
        FirstOrderKey = Text;
    }
    public Guid Id { get; }
    public string Text { get; }
    public int Level { get; }
    public string Meaning { get; }
    public string ExampleOfEnglish { get; }
    public string ExampleOfJapanese { get; }

    protected override bool EqualsCore(WordDTO other)
    {
        return Id == other.Id
            && Text == other.Text
            && Level == other.Level
            && Meaning == other.Meaning
            && ExampleOfEnglish == other.ExampleOfEnglish
            && ExampleOfJapanese == other.ExampleOfJapanese;
    }

    protected override int GetHashCodeCore()
    {
        return Id.GetHashCode();
    }
}
