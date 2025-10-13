using Pzl.Common;
using Pzl.Tools.Grids.Grids2d;

namespace Pzl.Aoc.Puzzles.Aoc2024.Aoc202420;

[Name("Race Condition")]
public class Aoc202420 : AocPuzzle
{
    public PuzzleResult Part1(string input)
    {
        var result = CountCheatsBetterThan(input, 2, 100);
        
        return new PuzzleResult(result, "345ad458eb8fecd2bee1b07cda111f5b");
    }

    public PuzzleResult Part2(string input)
    {
        var result = CountCheatsBetterThan(input, 20, 100);
        
        return new PuzzleResult(result, "180cd20a00ef865aeaee6f0f6484da86");
    }

    public static int CountCheatsBetterThan(string input, int radius, int limit) => 
        GetCheats(input, radius).Count(o => o.Value >= limit);

    public static Dictionary<(MatrixAddress from, MatrixAddress to), int> GetCheats(string input, int radius)
    {
        var matrix = MatrixBuilder.BuildCharMatrix(input);
        var start = matrix.FindAddresses('S').First();
        var end = matrix.FindAddresses('E').First();
        matrix.WriteValueAt(start, '.');
        matrix.WriteValueAt(end, '.');
        
        var path = PathFinder.ShortestPathTo(matrix, start, end);
        path = [start, ..path];
        
        var distanceToTarget = new Dictionary<MatrixAddress, int>();
        for (var i = 0; i < path.Count; i++)
        {
            distanceToTarget.Add(path[i], path.Count - i - 1);
        }

        var cheats = new Dictionary<(MatrixAddress from, MatrixAddress to), int>();
        foreach (var coord in path)
        {
            for (var y = -radius; y <= radius; y++)
            {
                for (var x = -radius; x <= radius; x++)
                {
                    if (Math.Abs(y) + Math.Abs(x) > radius)
                        continue;
                    
                    var nc = new MatrixAddress(coord.X + x, coord.Y + y);
                    if (matrix.IsOutOfRange(nc) || matrix.ReadValueAt(nc) == '#')
                        continue;

                    var diff = distanceToTarget[coord] - distanceToTarget[nc] - coord.ManhattanDistanceTo(nc);
                    if (diff > 0)
                        cheats.Add((coord, nc), diff);
                }
            }
        }

        return cheats;
    }
}