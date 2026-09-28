using Pzl.Common;
using Pzl.Tools.Grids.Grids3d;
using Pzl.Tools.Grids.Grids4d;

namespace Pzl.Aoc.Puzzles.Aoc2020;

[Name("Conway Cubes")]
public class Aoc202017 : AocPuzzle
{
    [Puzzle("86fb7e6bf0dd282e332fdf0fe14cb572")]
    public int Part1(string input) => new ConwayCube().Boot3D(input, 6);

    [Puzzle("7d43e2d315b28ef823069e2b5aef74e8")]
    public int Part2(string input) => new ConwayCube().Boot4D(input, 6);

    public class ConwayCube
    {
        public int Boot3D(string input, int iterations)
        {
            var grid = Grid3dBuilder.BuildCharGrid(input, '.');

            for (var i = 0; i < iterations; i++)
            {
                grid.ExtendAllDirections();
                var ons = new List<Coord3d>();
                for (var z = grid.ZMin; z <= grid.ZMax; z++)
                {
                    for (var y = grid.YMin; y <= grid.YMax; y++)
                    {
                        for (var x = grid.XMin; x <= grid.XMax; x++)
                        {
                            grid.MoveTo(x, y, z);
                            var currentValue = grid.ReadValue();
                            var adjacentValues = grid.AllAdjacentValues;
                            var neighborCount = adjacentValues.Count(o => o == '#');
                            var newValue = GetNewValue(currentValue, neighborCount);
                            if (newValue == '#')
                                ons.Add(grid.Address);
                        }
                    }
                }

                grid.Clear();
                foreach (var coord in ons)
                    grid.WriteValueAt(coord, '#');
            }

            return grid.Values.Count(o => o == '#');
        }

        public int Boot4D(string input, int iterations)
        {
            var grid = Grid4dBuilder.BuildCharGrid(input, '.');

            for (var i = 0; i < iterations; i++)
            {
                grid.ExtendAllDirections();
                var newGrid = new Grid4d<char>(1, 1, 1, 1, '.');
                for (var w = 0; w < grid.Duration; w++)
                {
                    for (var z = 0; z < grid.Depth; z++)
                    {
                        for (var y = 0; y < grid.Height; y++)
                        {
                            for (var x = 0; x < grid.Width; x++)
                            {
                                grid.MoveTo(x, y, z, w);
                                var currentValue = grid.ReadValue();
                                var adjacentValues = grid.AllAdjacentValues;
                                var neighborCount = adjacentValues.Count(o => o == '#');
                                var newValue = GetNewValue(currentValue, neighborCount);
                                newGrid.MoveTo(x, y, z, w);
                                newGrid.WriteValue(newValue);
                            }
                        }
                    }
                }

                newGrid.StartAddress = grid.StartAddress;
                grid = newGrid;

            }

            return grid.Values.Count(o => o == '#');
        }

        private static char GetNewValue(char currentValue, int neighborCount) => currentValue switch
        {
            '#' when neighborCount != 2 && neighborCount != 3 => '.',
            '.' when neighborCount == 3 => '#',
            _ => currentValue
        };
    }
}