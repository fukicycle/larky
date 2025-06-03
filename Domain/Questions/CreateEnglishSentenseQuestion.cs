using Domain.Entities;
using Domain.Interfaces;

namespace Domain.Questions;

public sealed class CreateEnglishSentenseQuestion : IQuestion
{
    private readonly Word _word;
    public CreateEnglishSentenseQuestion(Word word)
    {
        _word = word;
    }
    public string QuestionOfEnglish => "Put the words in the correct order to make a sentence.";
    public string QuestionOfJapanese => "選択肢を並び替えて英文を完成させてください。";
    public string Answer => _word.ExampleOfEnglish;
    public IEnumerable<string> ChoiceItems => CreateChoiceItems();

    public bool CheckAnswer(string? userAnswer)
    {
        return userAnswer + "." == Answer;
    }

    private IEnumerable<string> CreateChoiceItems()
    {
        var items = _word.ExampleOfEnglish.Split(' ');
        return items.Select(a => a.Replace(".", "")).OrderBy(a => Random.Shared.Next());
    }
}
