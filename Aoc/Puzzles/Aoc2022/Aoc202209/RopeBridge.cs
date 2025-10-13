using Pzl.Tools.Grids.Grids2d;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2022.Aoc202209;

public class RopeBridge
{
    public int Part1(string input)
    {
        return Run(input, 2);
    }

    public int Part2(string input)
    {
        return Run(input, 10);
    }

    private int Run(string input, int knotCount)
    {
        var lines = StringReader.ReadLines(input, false);
        var visited = new HashSet<Coord>();
        var knots = new Coord[knotCount];
        for (var i = 0; i < knotCount; i++)
        {
            knots[i] = new Coord(0, 0);
        }
        
        visited.Add(knots.Last());

        foreach (var line in lines)
        {
            var parts = line.Split(' ');
            var direction = parts[0];
            var distance = int.Parse(parts[1]);

            for (var i = 0; i < distance; i++)
            {
                knots[0] = GetPosAfterMove(knots[0], direction);

                for (var j = 1; j < knots.Length; j++)
                {
                    var diffX = knots[j].X - knots[j - 1].X;
                    var diffY = knots[j].Y - knots[j - 1].Y;
                    var isDiagonalDiff = diffX != 0 && diffY != 0;
                    var diff = Math.Abs(diffX) + Math.Abs(diffY);
                    var shouldFollowDiagonally = isDiagonalDiff && diff > 2;
                    var shouldFollowStraight = !isDiagonalDiff && diff > 1;
                    var shouldFollow = shouldFollowDiagonally || shouldFollowStraight;
                    if (shouldFollow)
                    {
                        var xSteps = diffX != 0 ? diffX / Math.Abs(diffX) : 0;
                        var ySteps = diffY != 0 ? diffY / Math.Abs(diffY) : 0;
                        knots[j] = new Coord(knots[j].X - xSteps, knots[j].Y - ySteps);
                    }
                }

                visited.Add(knots.Last());
            }
        }
        var result = visited.Count;

        return result;
    }

    private Coord GetPosAfterMove(Coord coord, string direction)
    {
        return direction switch
        {
            "U" => new Coord(coord.X, coord.Y + 1),
            "R" => new Coord(coord.X + 1, coord.Y),
            "D" => new Coord(coord.X, coord.Y - 1),
            _ => new Coord(coord.X - 1, coord.Y)
        };
    }

    private GridDirection GetDir(string part)
    {
        return part switch
        {
            "U" => GridDirection.Up,
            "R" => GridDirection.Right,
            "D" => GridDirection.Down,
            _ => GridDirection.Left
        };
    }
}