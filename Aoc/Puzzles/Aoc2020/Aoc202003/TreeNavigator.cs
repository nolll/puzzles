using Pzl.Tools.Grids.Grids2d;

namespace Pzl.Aoc.Puzzles.Aoc2020.Aoc202003;

public class TreeNavigator(string input)
{
    public long GetTreeCount(TreeTrajectory trajectory)
    {
        var grid = GridBuilder.BuildCharGrid(input);
        grid.MoveTo(0, 0);

        var treeCount = 0;
        while (!grid.IsAtBottomEdge)
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

    public long GetSingleTreeCount()
    {
        return GetTreeCount(new TreeTrajectory(3, 1));
    }

    public IEnumerable<long> GetAllTreeCounts() => Trajectories.Select(GetTreeCount);

    private static List<TreeTrajectory> Trajectories =>
    [
        new(1, 1),
        new(3, 1),
        new(5, 1),
        new(7, 1),
        new(1, 2)
    ];
}