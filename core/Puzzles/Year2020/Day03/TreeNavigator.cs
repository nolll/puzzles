using System.Collections.Generic;
using System.Linq;
using Core.Common.CoordinateSystems.CoordinateSystem2D;

namespace Core.Puzzles.Year2020.Day03;

public class TreeNavigator
{
    private readonly string _input;

    public TreeNavigator(string input)
    {
        _input = input;
    }

    public long GetTreeCount(TreeTrajectory trajectory)
    {
        var matrix = MatrixBuilder.BuildQuickCharMatrix(_input);
        matrix.MoveTo(0, 0);

        var treeCount = 0;
        while (!matrix.IsAtBottom)
        {
            for (var i = 0; i < trajectory.Right; i++)
            {
                var movedRight = matrix.TryMoveRight();
                if (!movedRight)
                    matrix.MoveTo(0, matrix.Address.Y);
            }

            for (var i = 0; i < trajectory.Down; i++)
                matrix.MoveDown();

            var hasTree = matrix.ReadValue() == '#';
            treeCount += hasTree ? 1 : 0;
        }

        return treeCount;
    }

    public long GetSingleTreeCount()
    {
        return GetTreeCount(new TreeTrajectory(3, 1));
    }

    public IEnumerable<long> GetAllTreeCounts()
    {
        var trajectories = new List<TreeTrajectory>
        {
            new(1, 1),
            new(3, 1),
            new(5, 1),
            new(7, 1),
            new(1, 2)
        };

        return trajectories.Select(GetTreeCount);
    }
}