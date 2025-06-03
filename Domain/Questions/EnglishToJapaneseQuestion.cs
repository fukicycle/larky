using Domain.Entities;
using Domain.Interfaces;

namespace Domain.Questions;

public sealed class EnglishToJapaneseQuestion : IQuestion
{
    private readonly Word _word;
    public EnglishToJapaneseQuestion(Word word)
    {
        _word = word;
    }

    public string QuestionOfEnglish => _word.Text;
    public string QuestionOfJapanese => string.Empty;
    public string Answer => _word.Meaning;
    public IEnumerable<string> ChoiceItems => Enumerable.Empty<string>();

    public bool CheckAnswer(string? userAnswer)
    {
        return userAnswer == Answer;
    }
}
