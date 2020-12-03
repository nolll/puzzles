using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.Tools;

namespace Core.TreeNavigation
{
    public class TreeNavigator
    {
        private readonly string _input;

        public TreeNavigator(string input)
        {
            _input = input;
        }

        private string ExpandInput(string input, TreeTrajectory trajectory)
        {
            var rows = input.Trim().Split('\n').Select(o => o.Trim()).ToList();
            var height = rows.Count;
            var requiredWidth = height / trajectory.Down * trajectory.Right;
            for (var r = 0; r < rows.Count; r++)
            {
                var row = rows[r];
                while (rows[r].Length < requiredWidth)
                {
                    rows[r] += row;
                }
            }

            return string.Join("\n\r", rows);
        }

        public long GetTreeCount(TreeTrajectory trajectory)
        {
            var largeInput = ExpandInput(_input, trajectory);
            var matrix = MatrixBuilder.BuildCharMatrix(largeInput);
            matrix.MoveTo(0, 0);

            var treeCount = 0;
            while (!matrix.IsAtBottom)
            {
                var movedRight = matrix.TryMoveRight(trajectory.Right);
                if (!movedRight)
                    throw new Exception("Can't move right");

                for (var i = 0; i < trajectory.Down; i++)
                    matrix.MoveDown();

                treeCount += matrix.ReadValue() == '#' ? 1 : 0;
                matrix.WriteValue('X');
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
                new TreeTrajectory(1, 1),
                new TreeTrajectory(3, 1),
                new TreeTrajectory(5, 1),
                new TreeTrajectory(7, 1),
                new TreeTrajectory(1, 2)
            };

            return trajectories.Select(GetTreeCount);
        }
    }
}