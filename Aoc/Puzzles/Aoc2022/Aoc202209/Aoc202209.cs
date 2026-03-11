using Pzl.Common;
using Pzl.Tools.Grids.Grids2d;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2022.Aoc202209;

[Name("Rope Bridge")]
public class Aoc202209 : AocPuzzle
{
    [Puzzle("5b3410f2b268346d61d197ac2087314e")]
    public int Part1(string input) => Solve(input, 2);

    [Puzzle("05bd61537764e7f00abe6ea63344d6ba")]
    public int Part2(string input) => Solve(input, 10);
    
    private int Solve(string input, int knotCount)
    {
        var lines = input.Split(LineBreaks.Single).Where(o => o.Length > 0);
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
                    if (!shouldFollow) 
                        continue;
                    
                    var xSteps = diffX != 0 ? diffX / Math.Abs(diffX) : 0;
                    var ySteps = diffY != 0 ? diffY / Math.Abs(diffY) : 0;
                    knots[j] = new Coord(knots[j].X - xSteps, knots[j].Y - ySteps);
                }

                visited.Add(knots.Last());
            }
        }
        var result = visited.Count;

        return result;
    }

    private static Coord GetPosAfterMove(Coord coord, string direction) => direction switch
    {
        "U" => new Coord(coord.X, coord.Y + 1),
        "R" => new Coord(coord.X + 1, coord.Y),
        "D" => new Coord(coord.X, coord.Y - 1),
        _ => new Coord(coord.X - 1, coord.Y)
    };
}