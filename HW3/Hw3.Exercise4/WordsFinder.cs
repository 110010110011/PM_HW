#pragma warning disable IDE0160
namespace Hw3.Exercise4;
#pragma warning restore IDE0160

public static class WordsFinder
{
    public static List<string>? FindWords(string word, List<string> listOfWords)
    {
        if (listOfWords is null || word is null)
            throw new ArgumentNullException();

        var letterFreq = GetLetterFreq(word);

        var letterFreqInWords = listOfWords
                .Select(GetLetterFreq);

        var wordsIndexes = letterFreqInWords
            .Select((item, index) => (item, index))
            .Where(i => i.item
                .OrderBy(x => x.Key)
                .SequenceEqual(letterFreq
                    .OrderBy(x => x.Key)))
            .Select(x => x.index);

        return listOfWords
            .Select((item, index) => (item, index))
            .Where(i => wordsIndexes.Any(x => x == i.index))
            .Select(x => x.item).ToList();
    }

    private static Dictionary<char, int> GetLetterFreq(string word)
    {
        return word.Distinct()
            .Select(
                letter => new
                {
                    letter,
                    count = word.Count(x => x == letter)
                })
            .ToDictionary(letter => letter.letter, letter => letter.count);
    }
}
