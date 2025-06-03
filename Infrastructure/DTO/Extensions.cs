using System;
using Domain.Entities;

namespace Infrastructure.DTO;

public static class Extensions
{
    public static WordDTO ToDTO(this Word word)
    {
        return new WordDTO(word.Id, word.Text, word.Level, word.Meaning, word.ExampleOfEnglish, word.ExampleOfJapanese);
    }

    public static Word ToDomain(this WordDTO wordDTO)
    {
        return new Word(wordDTO.Id, wordDTO.Text, wordDTO.Level, wordDTO.Meaning, wordDTO.ExampleOfEnglish, wordDTO.ExampleOfJapanese);
    }

    public static IEnumerable<WordDTO> ToDTO(this IEnumerable<Word> words)
    {
        return words.Select(word => word.ToDTO());
    }

    public static IEnumerable<Word> ToDomain(this IEnumerable<WordDTO> wordDTOs)
    {
        return wordDTOs.Select(wordDTO => wordDTO.ToDomain());
    }
}
