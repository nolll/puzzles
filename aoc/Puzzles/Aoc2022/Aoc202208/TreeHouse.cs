using Puzzles.common.CoordinateSystems.CoordinateSystem2D;
using Puzzles.common.Strings;

namespace Puzzles.aoc.Puzzles.Aoc2022.Aoc202208;

public class TreeHouse
{
    private readonly Matrix<int> _treeMatrix;
    private readonly Matrix<bool> _part1Matrix;
    private readonly Matrix<int> _part2Matrix;
    private readonly MatrixDirection[] _directions;

    public int VisibleTreesCount { get; private set; }
    public int HighestScenicScore { get; private set; }

    public TreeHouse(string input)
    {
        var lines = StringReader.ReadLines(input, false);
        var patchWidth = lines[0].Length;
        var patchHeight = lines.Count;
        _treeMatrix = MatrixBuilder.BuildIntMatrixFromNonSeparated(input);
        _part1Matrix = new Matrix<bool>(patchWidth, patchHeight);
        _part2Matrix = new Matrix<int>(patchWidth, patchHeight);
        _directions = new [] {MatrixDirection.Up, MatrixDirection.Right, MatrixDirection.Down, MatrixDirection.Left };
    }

    public void Calc()
    {
        foreach (var coord in _treeMatrix.Coords)
        {
            var visibility = new Dictionary<MatrixDirection, bool>
            {
                [MatrixDirection.Up] = true,
                [MatrixDirection.Right] = true,
                [MatrixDirection.Down] = true,
                [MatrixDirection.Left] = true
            };

            var scenicScores = new Dictionary<MatrixDirection, int>
            {
                [MatrixDirection.Up] = 0,
                [MatrixDirection.Right] = 0,
                [MatrixDirection.Down] = 0,
                [MatrixDirection.Left] = 0
            };

            _treeMatrix.MoveTo(coord);
            var currentTreeHeight = _treeMatrix.ReadValue();

            foreach (var direction in _directions)
            {
                _treeMatrix.TurnTo(direction);
                while (_treeMatrix.TryMoveForward())
                {
                    scenicScores[direction]++;
                    if (_treeMatrix.ReadValue() >= currentTreeHeight)
                    {
                        visibility[direction] = false;
                        break;
                    }
                }

                _treeMatrix.MoveTo(coord);
            }

            var isVisible = visibility.Values.Count(o => o) > 0;
            _part1Matrix.WriteValueAt(coord, isVisible);

            var scenicScore = scenicScores.Values.Aggregate(1, (x, y) => x * y);
            _part2Matrix.WriteValueAt(coord, scenicScore);
        }

        VisibleTreesCount = _part1Matrix.Values.Count(o => o);
        HighestScenicScore = _part2Matrix.Values.Max();
    }
}