using Domain.Entities;
using Domain.Questions;

namespace XTest;

public class QuestionTest
{
    private static Word word = new Word(Guid.NewGuid(), "Word", 0, "単語", "My favorite word is Food.", "私の好きな単語は食料です。");
    [Fact]
    public void 英単語から日本語を回答する問題が正しく動作する()
    {
        var question = new EnglishToJapaneseQuestion(word);
        question.QuestionOfEnglish.Is("Word");
        question.QuestionOfJapanese.Is(string.Empty);
        question.Answer.Is("単語");
        question.ChoiceItems.Is(Enumerable.Empty<string>());
        question.CheckAnswer("単語").IsTrue();
    }

    [Fact]
    public void 英語例文に正しい単語を埋める問題が正しく動作する()
    {
        var question = new FillWordInBlankQuestion(word);
        question.QuestionOfEnglish.Is("My favorite ____ is Food.");
        question.QuestionOfJapanese.Is("私の好きな単語は食料です。");
        question.Answer.Is("word");
        question.ChoiceItems.Is(Enumerable.Empty<string>());
        question.CheckAnswer("word").IsTrue();
    }

    [Fact]
    public void 並び替えて英文を完成させる問題が正しく動作する()
    {
        var question = new CreateEnglishSentenseQuestion(word);
        question.QuestionOfEnglish.Is("Put the words in the correct order to make a sentence.");
        question.QuestionOfJapanese.Is("選択肢を並び替えて英文を完成させてください。");
        question.Answer.Is("My favorite word is Food.");
        var choices = new[] { "My", "favorite", "word", "is", "Food" };
        question.ChoiceItems.All(a => choices.Contains(a)).IsTrue();
        question.CheckAnswer("My favorite word is Food").IsTrue();
    }
}