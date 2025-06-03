namespace Domain.Interfaces;

public interface IQuestion
{
    string QuestionOfEnglish { get; }
    string QuestionOfJapanese { get; }
    string Answer { get; }
    IEnumerable<string> ChoiceItems { get; }
    bool CheckAnswer(string? userAnswer);
}
