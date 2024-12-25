using Pzl.Common;
using Pzl.Tools.CoordinateSystems.CoordinateSystem2D;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2024.Aoc202425;

[Name("Code Chronicle")]
public class Aoc202425 : AocPuzzle
{
    public PuzzleResult Part1(string input)
    {
        var parts = input.Split(LineBreaks.Double);
        var locks = new List<int[]>();
        var keys = new List<int[]>();
        foreach (var part in parts)
        {
            var matrix = MatrixBuilder.BuildCharMatrix(part);
            int[] a = [0, 0, 0, 0, 0];
            for (var x = 0; x < matrix.Width; x++)
            {
                for (var y = 1; y < matrix.Height - 1; y++)
                {
                    if(matrix.ReadValueAt(x, y) == '#')
                        a[x]++;
                }
            }
            
            var isLock = IsLock(matrix);
            if(isLock)
                locks.Add(a);
            else
                keys.Add(a);
        }

        var matchCount = locks.Sum(l => keys.Sum(k => IsMatch(l, k) ? 1 : 0));

        return new PuzzleResult(matchCount, "ff96adb8fa4ccab9294acf5f8c332256");
    }

    private static bool IsMatch(int[] l, int[] k) => !l.Where((t, i) => k[i] + t > 5).Any();

    private static bool IsLock(Matrix<char> matrix)
    {
        for (var x = 0; x < matrix.Width; x++)
        {
            if (matrix.ReadValueAt(x, 0) == '.')
                return false;
        }
        return true;
    }
}