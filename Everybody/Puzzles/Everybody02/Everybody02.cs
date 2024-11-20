using Pzl.Common;
using Pzl.Tools.CoordinateSystems.CoordinateSystem2D;
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
        var count = CountRunicSymbolsInMatrix(inputs[2]);
        
        return new PuzzleResult(count, "45b4423987a6cf8c24dba08ecb86fc71");
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
    
    private static int CountRunicSymbolsInMatrix(string input)
    {
        var parts = input.Split($"{Environment.NewLine}", StringSplitOptions.RemoveEmptyEntries);
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
            var reversedWord = word.ReverseString();
            var hits = new List<(int, int)>();
            var rowNr = 0;
            foreach (var row in horizontalRows)
            {
                var found = Search(row, word);
                var foundReversed = Search(row, reversedWord);
                found.AddRange(foundReversed);
                hits.AddRange(found.Select(o => (o % rowWidth, rowNr)));
                rowNr++;
            }
            
            var colNr = 0;
            foreach (var row in verticalRows)
            {
                var found = Search(row, word);
                var foundReversed = Search(row, reversedWord);
                found.AddRange(foundReversed);
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

    private static List<int> Search(string s, string word)
    {
        var hits = new List<int>();
        
        for (var i = 0; i < s.Length - word.Length + 1; i++)
        {
            var current = s.Substring(i, word.Length);
            if (current == word)
            {
                for (var j = i; j < i + word.Length; j++)
                {
                    hits.Add(j);
                }
            }
        }

        return hits;
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