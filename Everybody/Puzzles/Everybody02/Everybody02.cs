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
        
        // 10203, correct length, correct first letter
        
        return new PuzzleResult(count);
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
        return CountRunicSymbols(words.Split(','), s);
    }
    
    public static int CountRunicSymbolsInMatrix(string[] words, string[] rows)
    {
        var wrappingRows = rows.Select(o => $"{o}{o}");
        var wrappingMatrixInput = string.Join(Environment.NewLine, wrappingRows);
        var wrappingMatrix = MatrixBuilder.BuildCharMatrix(wrappingMatrixInput);
        
        var matrixInput = string.Join(Environment.NewLine, rows);
        var matrix = MatrixBuilder.BuildCharMatrix(matrixInput);
        
        var set = new HashSet<(int, int)>();

        foreach (var word in words)
        {
            var hits = new List<MatrixAddress>();
            for (var row = matrix.YMin; row <= matrix.YMax; row++)
            {
                hits.AddRange(SearchRight(wrappingMatrix, row, word));
                hits.AddRange(SearchRight(wrappingMatrix, row, word.ReverseString()));
            }
            
            for (var col = matrix.XMin; col <= matrix.XMax; col++)
            {
                hits.AddRange(SearchDown(matrix, col, word));
                hits.AddRange(SearchDown(matrix, col, word.ReverseString()));
            }

            foreach (var hit in hits)
            {
                set.Add((hit.X, hit.Y));
            }
        }

        foreach (var v in set)
        {
            matrix.WriteValueAt(v.Item1, v.Item2, '_');
        }
        
        Console.WriteLine(matrix.Print());

        return set.Count;
    }

    private static List<MatrixAddress> SearchRight(Matrix<char> matrix, int row, string word)
    {
        var realWidth = matrix.Width / 2;
        var hits = new List<MatrixAddress>();
        
        for (var startCol = matrix.XMin; startCol <= matrix.XMax - word.Length + 1; startCol++)
        {
            var currentWord = "";
            var curPositions = new List<MatrixAddress>();
            for (var col = startCol; col < startCol + word.Length; col++)
            {
                var curPos = new MatrixAddress(col % realWidth, row);
                curPositions.Add(curPos);
                currentWord += matrix.ReadValueAt(curPos);
            }

            if (currentWord == word)
            {
                hits.AddRange(curPositions);
            }
        }
        return hits;
    }
    
    private static List<MatrixAddress> SearchDown(Matrix<char> matrix, int col, string word)
    {
        var hits = new List<MatrixAddress>();
        for (var startRow = matrix.YMin; startRow <= matrix.YMax - word.Length + 1; startRow++)
        {
            var currentWord = "";
            var curPositions = new List<MatrixAddress>();
            for (var row = startRow; row < startRow + word.Length; row++)
            {
                var curPos = new MatrixAddress(col, row);
                curPositions.Add(curPos);
                currentWord += matrix.ReadValueAt(curPos);
            }

            if (currentWord == word)
            {
                hits.AddRange(curPositions);
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