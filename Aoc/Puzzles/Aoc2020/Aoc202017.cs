using Pzl.Common;
using Pzl.Tools.Grids.Grids3D;
using Pzl.Tools.Grids.Grids4d;

namespace Pzl.Aoc.Puzzles.Aoc2020;

[Name("Conway Cubes")]
public class Aoc202017 : AocPuzzle
{
    private const int CycleCount = 6;

    [Puzzle("86fb7e6bf0dd282e332fdf0fe14cb572")]
    public int Part1(string input)
    {
        var grid = Grid3DBuilder.BuildCharGrid(input, '.');

        for (var i = 0; i < CycleCount; i++)
        {
            grid.ExtendAllDirections();
            var ons = new List<Coord3D>();
            foreach (var coord in grid.Coords)
            {
                var currentValue = grid.ReadValueAt(coord);
                var adjacentValues = grid.AllAdjacentValuesTo(coord);
                var neighborCount = adjacentValues.Count(o => o == '#');
                var newValue = GetNewValue(currentValue, neighborCount);
                if (newValue == '#')
                    ons.Add(coord);
            }

            grid.Clear();
            foreach (var coord in ons)
                grid.WriteValueAt(coord, '#');
        }

        return grid.Values.Count(o => o == '#');
    }

    [Puzzle("7d43e2d315b28ef823069e2b5aef74e8")]
    public int Part2(string input)
    {
        var grid = Grid4DBuilder.BuildCharGrid(input, '.');

        for (var i = 0; i < CycleCount; i++)
        {
            grid.ExtendAllDirections();
            var newGrid = new Grid4D<char>(1, 1, 1, 1, '.');

            foreach (var coord in grid.Coords)
            {
                var currentValue = grid.ReadValueAt(coord);
                var adjacentValues = grid.AllAdjacentValuesTo(coord);
                var neighborCount = adjacentValues.Count(o => o == '#');
                newGrid.WriteValueAt(coord, GetNewValue(currentValue, neighborCount));
            }

            newGrid.StartCoord = grid.StartCoord;
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