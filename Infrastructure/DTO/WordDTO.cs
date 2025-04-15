namespace Infrastructure.DTO;

public sealed class WordDTO
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
}
