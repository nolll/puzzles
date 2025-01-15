using Pzl.Common;
using Pzl.Tools.CoordinateSystems.CoordinateSystem2D;

namespace Pzl.Everybody.Puzzles.Everybody17;

[Name("Galactic Geometry")]
public class Everybody17 : EverybodyPuzzle
{
    public PuzzleResult Part1(string input)
    {
        var grid = MatrixBuilder.BuildCharMatrix(input);
        var stars = grid.FindAddresses('*');

        var distances = new Dictionary<(MatrixAddress a, MatrixAddress b), int>();
        foreach (var a in stars)
        {
            foreach (var b in stars)
            {
                if (a.Equals(b))
                    continue;
                
                distances.Add((a, b), a.ManhattanDistanceTo(b));
            }
        }
        
        return new PuzzleResult(0);
    }

    public PuzzleResult Part2(string input)
    {
        return new PuzzleResult(0);
    }

    public PuzzleResult Part3(string input)
    {
        return new PuzzleResult(0);
    }
}