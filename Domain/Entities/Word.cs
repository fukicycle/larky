namespace Domain.Entities;

public sealed class Word
{
    public Word(
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
    }
    public Guid Id { get; }
    public string Text { get; }
    public int Level { get; }
    public string Meaning { get; }
    public string ExampleOfEnglish { get; }
    public string ExampleOfJapanese { get; }
}
