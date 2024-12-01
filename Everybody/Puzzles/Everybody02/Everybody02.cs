using NUnit.Framework.Internal;
using Pzl.Common;
using Pzl.Tools.CoordinateSystems.CoordinateSystem2D;
using Pzl.Tools.Strings;

namespace Pzl.Everybody.Puzzles.Everybody02;

[Name("The Runes of Power")]
public class Everybody02 : EverybodyPuzzle
{
    protected override PuzzleResult RunPart1(string input)
    {
        var count = CountRunicWords(input);
        
        return new PuzzleResult(count, "a95c75956922f6f91c685f01d8548eb1");
    }
    
    protected override PuzzleResult RunPart2(string input)
    {
        var count = CountRunicSymbols(input);
        
        return new PuzzleResult(count, "df79c139a238567f7809c68a9e99d7bc");
    }
    
    protected override PuzzleResult RunPart3(string input)
    {
        var count = CountRunicSymbolsInMatrix(input);
        
        return new PuzzleResult(count, "45b4423987a6cf8c24dba08ecb86fc71");
    }

    private static int CountRunicWords(string input)
    {
        var parts = input.Split(LineBreaks.Single, StringSplitOptions.RemoveEmptyEntries);
        var words = parts.First().Split(':').Last();
        var s = parts.Last();
        return CountRunicWords(words.Split(','), [s]);
    }
    
    public static int CountRunicWords(string[] words, string[] strings) => 
        strings.Sum(s => words.Sum(o => OccurrencesInString(o, s)));

    private static int CountRunicSymbols(string input)
    {
        var parts = input.Split(LineBreaks.Single, StringSplitOptions.RemoveEmptyEntries);
        var words = parts.First().Split(':').Last();
        var s = parts.Skip(1).ToArray();
        return CountRunicSymbols(words.Split(','), s);
    }
    
    public static int CountRunicSymbols(string[] words, string[] strings) => 
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

    private static int CountRunicSymbolsInMatrix(string input)
    {
        var parts = input.Split($"{LineBreaks.Single}", StringSplitOptions.RemoveEmptyEntries);
        var words = parts.First().Split(':').Last();
        var s = parts.Skip(1).ToArray();
        return CountRunicSymbolsInMatrix(words.Split(','), s);
    }
    
    public static int CountRunicSymbolsInMatrix(string[] words, string[] rows)
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