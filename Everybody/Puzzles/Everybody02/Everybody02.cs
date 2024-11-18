using Pzl.Common;
using Pzl.Tools.Strings;

namespace Pzl.Everybody.Puzzles.Everybody02;

[Name("The Runes of Power")]
public class Everybody02(string[] inputs) : EverybodyPuzzle
{
    protected override PuzzleResult RunPart1()
    {
        var count = CountRunicWords(inputs[0]);
        
        return new PuzzleResult(count, "a95c75956922f6f91c685f01d8548eb1");
    }
    
    protected override PuzzleResult RunPart2()
    {
        var count = CountRunicSymbols(inputs[1]);
        
        return new PuzzleResult(count, "df79c139a238567f7809c68a9e99d7bc");
    }
    
    protected override PuzzleResult RunPart3()
    {
        return PuzzleResult.Empty;
    }

    private static int CountRunicWords(string input)
    {
        var parts = input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
        var words = parts.First().Split(':').Last();
        var s = parts.Last();
        return CountRunicWords(words.Split(','), [s]);
    }
    
    public static int CountRunicWords(string[] words, string[] strings)
    {
        var count = 0;
        foreach (var s in strings)
        {
            count += words.Sum(o => OccurrencesInString(o, s));
        }

        return count;
    }
    
    private static int CountRunicSymbols(string input)
    {
        var parts = input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
        var words = parts.First().Split(':').Last();
        var s = parts.Skip(1).ToArray();
        return CountRunicSymbols(words.Split(','), s);
    }
    
    public static int CountRunicSymbols(string[] words, string[] strings)
    {
        var count = 0;
        foreach (var s in strings)
        {
            var set = new HashSet<int>();
            foreach (var word in words)
            {
                set = SymbolsHit(word, s, set);
                set = SymbolsHit(word.ReverseString(), s, set);
            }

            count += set.Count;
        }

        return count;
    }

    private static int OccurrencesInString(string word, string s)
    {
        var count = 0;
        for (var i = 0; i < s.Length - word.Length; i++)
        {
            var current = s.Substring(i, word.Length);
            if (current == word)
                count++;
        }

        return count;
    }
    
    private static HashSet<int> SymbolsHit(string word, string s, HashSet<int> set)
    {
        for (var i = 0; i < s.Length - word.Length + 1; i++)
        {
            var current = s.Substring(i, word.Length);
            if (current == word)
            {
                for (var j = i; j < i + word.Length; j++)
                {
                    set.Add(j);
                }
            }
        }

        return set;
    }
}