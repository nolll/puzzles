using Pzl.Common;
using Pzl.Tools.HashSets;
using Pzl.Tools.Strings;

namespace Pzl.Everybody.Puzzles.Ece2024.Ece202402;

[Name("The Runes of Power")]
public class Ece202402 : EverybodyEventPuzzle
{
    public PuzzleResult RunPart1(string input)
    {
        var (words, strings) = ParseWordsAndStrings(input);
        var count = CountRunicWords(words, strings);
        
        return new PuzzleResult(count, "a95c75956922f6f91c685f01d8548eb1");
    }

    public PuzzleResult RunPart2(string input)
    {
        var (words, strings) = ParseWordsAndStrings(input);
        var count = CountRunicSymbols(words, strings);
        
        return new PuzzleResult(count, "df79c139a238567f7809c68a9e99d7bc");
    }

    public PuzzleResult RunPart3(string input)
    {
        var (words, strings) = ParseWordsAndStrings(input);
        var count = CountRunicSymbolsInGrid(words, strings);
        
        return new PuzzleResult(count, "45b4423987a6cf8c24dba08ecb86fc71");
    }

    private static (string[] words, string[] strings) ParseWordsAndStrings(string input)
    {
        var parts = input.Split(LineBreaks.Single, StringSplitOptions.RemoveEmptyEntries);
        var words = parts.First().Split(':').Last().Split(',');
        var strings = parts.Skip(1).ToArray();
        return (words, strings);
    }

    public int CountRunicWords(string[] words, string[] strings) => 
        strings.Sum(s => words.Sum(o => OccurrencesInString(o, s)));

    public int CountRunicSymbols(string[] words, string[] strings) => 
        strings.Sum(s => CountRunicSymbols(words, s));

    private static int CountRunicSymbols(string[] words, string s)
    {
        var set = new HashSet<int>();
        foreach (var word in words)
        {
            set.AddRange(FindRunicSymbols(word, s));
        }

        return set.Count;
    }
    
    private static IEnumerable<int> FindRunicSymbols(string word, string s) => 
        FindMatchingIndices(s, word).Concat(FindMatchingIndices(s, word.ReverseString()));

    public int CountRunicSymbolsInGrid(string[] words, string[] rows)
    {
        var rowWidth = rows.First().Length;
        var horizontalRows = rows.Select(o => $"{o}{o}").ToList();
        var verticalRows = new List<string>();
        for (var i = 0; i < rowWidth; i++)
        {
            var s = rows.Aggregate("", (current, row) => current + row[i]);
            verticalRows.Add(s);
        }
        
        var set = new HashSet<(int, int)>();

        foreach (var word in words)
        {
            var hits = new List<(int, int)>();
            var rowNr = 0;
            foreach (var row in horizontalRows)
            {
                var found = FindRunicSymbols(word, row);
                hits.AddRange(found.Select(o => (o % rowWidth, rowNr)));
                rowNr++;
            }
            
            var colNr = 0;
            foreach (var row in verticalRows)
            {
                var found = FindRunicSymbols(word, row);
                hits.AddRange(found.Select(o => (colNr, o)));
                colNr++;
            }

            foreach (var hit in hits)
            {
                set.Add((hit.Item1, hit.Item2));
            }
        }
        
        return set.Count;
    }

    private static IEnumerable<int> FindMatchingIndices(string s, string word)
    {
        for (var i = 0; i < s.Length - word.Length + 1; i++)
        {
            if (s.Substring(i, word.Length) != word)
                continue;
            
            for (var j = i; j < i + word.Length; j++)
            {
                yield return j;
            }
        }
    }

    private static int OccurrencesInString(string word, string s) => 
        Enumerable.Range(0, s.Length - word.Length + 1)
            .Count(o => s.Substring(o, word.Length) == word);
}