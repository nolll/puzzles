using Pzl.Common;
using Pzl.Tools.Grids.Grids2d;

namespace Pzl.Aoc.Puzzles.Aoc2020;

[Name("Toboggan Trajectory")]
public class Aoc202003 : AocPuzzle
{
    [Puzzle("5523923bd52d76e1c1d68b1cfdff95b5")]
    public long Part1(string input) => GetTreeCount(input, new TreeTrajectory(3, 1));

    [Puzzle("2429f66aeab700cdc54b44c6b498a22b")]
    public long Part2(string input) => Trajectories.Select(o => GetTreeCount(input, o)).Aggregate((long)1, (a, b) => a * b);

    public long GetTreeCount(string input, TreeTrajectory trajectory)
    {
        var grid = GridBuilder.BuildCharGrid(input);
        grid.MoveTo(0, 0);

        var treeCount = 0;
        while (!grid.IsAtBottomEdge())
        {
            for (var i = 0; i < trajectory.Right; i++)
            {
                var movedRight = grid.TryMoveRight();
                if (!movedRight)
                    grid.MoveTo(0, grid.Coord.Y);
            }

            for (var i = 0; i < trajectory.Down; i++)
                grid.MoveDown();

            var hasTree = grid.ReadValue() == '#';
            treeCount += hasTree ? 1 : 0;
        }

        return treeCount;
    }

    private static List<TreeTrajectory> Trajectories =>
    [
        new(1, 1),
        new(3, 1),
        new(5, 1),
        new(7, 1),
        new(1, 2)
    ];

    public record TreeTrajectory(int Right, int Down);
}