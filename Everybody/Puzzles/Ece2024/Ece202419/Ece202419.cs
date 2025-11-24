using Pzl.Common;
using Pzl.Tools.Lists;
using Pzl.Tools.Strings;

namespace Pzl.Everybody.Puzzles.Ece2024.Ece202419;

// Thanks to Jonathan Paulson for part 3
[Name("Encrypted Duck")]
public class Ece202419 : EverybodyEventPuzzle
{
    private readonly Dictionary<(int dr, int dc), (int dr, int dc)> _rotations = new()
    {
        { (-1, -1), (-1, 0) },
        { (-1, 0), (-1, 1) },
        { (-1, 1), (0, 1) },
        { (0, 1), (1, 1) },
        { (1, 1), (1, 0) },
        { (1, 0), (1, -1) },
        { (1, -1), (0, -1) },
        { (0, -1), (-1, -1) }
    };

    public PuzzleResult Part1(string input) => new(Run(input, 1), "d9c02c79770322919192525a442c576d");
    public PuzzleResult Part2(string input) => new(Run(input, 100), "81f686ab8d66b6fc14b37f46ec85d6f2");
    public PuzzleResult Part3(string input) => new(Run(input, 1048576000), "4974156d795debf10be98bd14077a889");

    private string Run(string input, int iterations)
    {
        var (directions, encryptedMessage) = input.Split(LineBreaks.Double);
        var grid = GetGrid(encryptedMessage);
        var permutation = GetPermutation(grid, directions.ToCharArray());
        var extendedPermutation = ExtendPermutation(permutation, iterations);
        grid = ApplyPermutation(extendedPermutation, grid);

        var print = string.Join("", grid.Select(o => string.Join("", o)));
        return FindMessage(print);
    }

    private static char[][] GetGrid(string s)
    {
        var lines = s.Split(LineBreaks.Single);
        var width = lines[0].Length;
        var height = lines.Length;
        var grid = new char[height][];
        for (var r = 0; r < height; r++)
        {
            grid[r] = new char[width];
            for (var c = 0; c < width; c++)
            {
                grid[r][c] = lines[r][c];
            }
        }

        return grid;
    }

    private Dictionary<(int r, int c), (int r, int c)> GetPermutation(char[][] charGrid, char[] directions)
    {
        var height = charGrid.Length;
        var width = charGrid[0].Length;
        var coordGrid = new (int r, int c)[height][];
        for (var r = 0; r < height; r++)
        {
            coordGrid[r] = new (int r, int c)[width];
            for (var c = 0; c < width; c++)
            {
                coordGrid[r][c] = (r, c);
            }
        }

        var directionIndex = 0;
        for (var r = 0; r < height; r++)
        {
            for (var c = 0; c < width; c++)
            {
                if (r <= 0 || r >= height - 1 || c <= 0 || c >= width - 1)
                    continue;
                
                var direction = directions[directionIndex];
                directionIndex = (directionIndex + 1) % directions.Length;
                var old = _rotations.Keys.ToDictionary(k => k, v => coordGrid[r + v.dr][c + v.dc]);

                foreach (var item in _rotations)
                {
                    var (fr, fc) = direction == 'L' ? item.Key : item.Value;
                    var (tr, tc) = direction == 'L' ? item.Value : item.Key;
                    coordGrid[r + fr][c + fc] = old[(tr, tc)];
                }
            }
        }

        var transformed = new Dictionary<(int r, int c), (int r, int c)>();
        for (var r = 0; r < height; r++)
        {
            for (var c = 0; c < width; c++)
            {
                transformed[(r, c)] = coordGrid[r][c];
            }
        }

        return transformed;
    }

    private static Dictionary<(int r, int c), (int r, int c)> CombinePermutations(
        Dictionary<(int r, int c), (int r, int c)> p1, 
        Dictionary<(int r, int c), (int r, int c)> p2)
    {
        var result = new Dictionary<(int r, int c), (int r, int c)>();
        foreach (var key in p1.Keys)
        {
            result[key] = p1[p2[key]];
        }

        return result;
    }

    private static Dictionary<(int r, int c), (int r, int c)> ExtendPermutation(
        Dictionary<(int r, int c), (int r, int c)> permutation,
        int n)
    {
        if (n == 1)
            return permutation;
        if (n % 2 == 0)
            return ExtendPermutation(CombinePermutations(permutation, permutation), n / 2);
        return CombinePermutations(permutation, ExtendPermutation(permutation, n - 1));
    }

    private static char[][] ApplyPermutation(Dictionary<(int r, int c), (int r, int c)> p, char[][] initialGrid)
    {
        var height = initialGrid.Length;
        var width = initialGrid[0].Length;
        var resultGrid = new char[height][];
        for (var r = 0; r < height; r++)
        {
            resultGrid[r] = new char[width];
            for (var c = 0; c < width; c++)
            {
                var (pr, pc) = p[(r, c)];
                resultGrid[r][c] = initialGrid[pr][pc];
            }
        }

        return resultGrid;
    }
    
    private static string FindMessage(string s)
    {
        var start = s.IndexOf('>') + 1;
        var length = s.IndexOf('<') - start;

        return s.Substring(start, length);
    }
}