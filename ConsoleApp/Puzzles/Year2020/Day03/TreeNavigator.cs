using System.Collections.Generic;
using System.Linq;
using Core.Common.CoordinateSystems;

namespace ConsoleApp.Puzzles.Year2020.Day03
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
            var matrix = MatrixBuilder.BuildCharMatrix(_input);
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