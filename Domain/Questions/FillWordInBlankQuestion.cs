using System.Text.RegularExpressions;
using Domain.Entities;
using Domain.Interfaces;

namespace Domain.Questions;

public sealed class FillWordInBlankQuestion : IQuestion
{
    private readonly Word _word;
    public FillWordInBlankQuestion(Word word)
    {
        _word = word;
    }
    public string QuestionOfEnglish => CreateQuestion();
    public string QuestionOfJapanese => _word.ExampleOfJapanese;
    public string Answer => _word.Text.ToLower();
    public IEnumerable<string> ChoiceItems => Enumerable.Empty<string>();

    public bool CheckAnswer(string? userAnswer)
    {
        return userAnswer?.ToLower() == Answer.ToLower();
    }

    private string CreateQuestion()
    {
        var targetWord = _word.Text;
        var numberOfWord = _word.Text.Length;
        var blankChars = Enumerable.Range(0, numberOfWord).Select(a => "_");
        var replaceText = _word.ExampleOfEnglish.Replace(_word.Text, string.Join("", blankChars), StringComparison.CurrentCultureIgnoreCase);
        return replaceText;
    }
}
