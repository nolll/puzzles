using Pzl.Common;
using Pzl.Tools.Grids.Grids2d;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2022;

[Name("Treetop Tree House")]
public class Aoc202208 : AocPuzzle
{
    [Puzzle("db3773cdd4aa7c677d0d7b5276a6f31c")]
    public int Part1(string input)
    {
        var treeHouse = new TreeHouse(input);
        treeHouse.Calc();
        return treeHouse.VisibleTreesCount;
    }

    [Puzzle("20def27ee2db6df6b7e178884edb9c87")]
    public int? Part2(string input)
    {
        var treeHouse = new TreeHouse(input);
        treeHouse.Calc();
        return treeHouse?.HighestScenicScore;
    }

    public class TreeHouse
    {
        private readonly Grid<int> _treeGrid;
        private readonly Grid<bool> _part1Grid;
        private readonly Grid<int> _part2Grid;
        private readonly GridDirection[] _directions;

        public int VisibleTreesCount { get; private set; }
        public int HighestScenicScore { get; private set; }

        public TreeHouse(string input)
        {
            var lines = input.Split(LineBreaks.Single).Where(o => o.Length > 0).ToList();
            var patchWidth = lines[0].Length;
            var patchHeight = lines.Count;
            _treeGrid = GridBuilder.BuildIntGridFromNonSeparated(input);
            _part1Grid = new Grid<bool>(patchWidth, patchHeight);
            _part2Grid = new Grid<int>(patchWidth, patchHeight);
            _directions = [GridDirection.Up, GridDirection.Right, GridDirection.Down, GridDirection.Left];
        }

        public void Calc()
        {
            foreach (var coord in _treeGrid.Coords)
            {
                var visibility = new Dictionary<GridDirection, bool>
                {
                    [GridDirection.Up] = true,
                    [GridDirection.Right] = true,
                    [GridDirection.Down] = true,
                    [GridDirection.Left] = true
                };

                var scenicScores = new Dictionary<GridDirection, int>
                {
                    [GridDirection.Up] = 0,
                    [GridDirection.Right] = 0,
                    [GridDirection.Down] = 0,
                    [GridDirection.Left] = 0
                };

                _treeGrid.MoveTo(coord);
                var currentTreeHeight = _treeGrid.ReadValue();

                foreach (var direction in _directions)
                {
                    _treeGrid.TurnTo(direction);
                    while (_treeGrid.TryMoveForward())
                    {
                        scenicScores[direction]++;
                        if (_treeGrid.ReadValue() >= currentTreeHeight)
                        {
                            visibility[direction] = false;
                            break;
                        }
                    }

                    _treeGrid.MoveTo(coord);
                }

                var isVisible = visibility.Values.Count(o => o) > 0;
                _part1Grid.WriteValueAt(coord, isVisible);

                var scenicScore = scenicScores.Values.Aggregate(1, (x, y) => x * y);
                _part2Grid.WriteValueAt(coord, scenicScore);
            }

            VisibleTreesCount = _part1Grid.Values.Count(o => o);
            HighestScenicScore = _part2Grid.Values.Max();
        }
    }
}