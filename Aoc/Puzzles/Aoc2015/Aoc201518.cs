using Pzl.Common;
using Pzl.Tools.Grids.Grids2d;

namespace Pzl.Aoc.Puzzles.Aoc2015;

[Name("Like a GIF For Your Yard")]
public class Aoc201518 : AocPuzzle
{
    [Puzzle("cf54372c819da8af501619293a164f4f")]
    public int Part1(string input) => RunAnimation(input, 100);

    [Puzzle("91a84e73c4b0d0185f19367fdc75f4a7")]
    public int Part2(string input) => RunAnimation(input, 100, true);

    private const char LightOn = '#';
    private const char LightOff = '.';

    private static int LightCount(Grid<char> grid) => grid.Values.Count(o => o == LightOn);

    public int RunAnimation(string input, int steps, bool isCornersLit = false)
    {
        var grid = GridBuilder.BuildCharGrid(input);
        if (isCornersLit)
            TurnOnCornerLights(grid);
            
        for (var i = 0; i < steps; i++)
        {
            var newGrid = new Grid<char>();

            foreach (var coord in grid.Coords)
            {
                var adjacentValues = grid.AllAdjacentValuesTo(coord);
                newGrid.WriteValueAt(coord, GetNewState(grid.ReadValueAt(coord), adjacentValues.Count(o => o == LightOn)));
            }
            
            grid = newGrid;
            if (isCornersLit)
                TurnOnCornerLights(grid);
        }

        return LightCount(grid);
    }

    private static void TurnOnCornerLights(Grid<char> grid)
    {
        TurnOnLight(grid, grid.XMin, grid.YMin);
        TurnOnLight(grid, grid.XMax, grid.YMin);
        TurnOnLight(grid, grid.XMax, grid.YMax);
        TurnOnLight(grid, grid.XMin, grid.YMax);
    }

    private static void TurnOnLight(Grid<char> grid, int x, int y) => grid.WriteValueAt(x, y, LightOn);

    private static char GetNewState(in char value, in int adjacentOnCount) => value == LightOn
        ? adjacentOnCount is 2 or 3
            ? LightOn
            : LightOff
        : adjacentOnCount == 3
            ? LightOn
            : LightOff;
}