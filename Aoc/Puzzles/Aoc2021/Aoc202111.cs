using Pzl.Common;
using Pzl.Tools.Grids.Grids2d;

namespace Pzl.Aoc.Puzzles.Aoc2021;

[Name("Dumbo Octopus")]
public class Aoc202111 : AocPuzzle
{
    [Puzzle("4aec5027d57e852d3dc2c0fa275d9d7a")]
    public int Part1(string input) => Solve(input, 100);

    [Puzzle("ffd6657cda58c97fce2c4c27d8fd43a9")]
    public int Part2(string input) => Solve(input);

    public int Solve(string input, int? maxSteps = null)
    {
        var grid = GridBuilder.BuildIntGridFromNonSeparated(input);
        var coords = grid.Coords.ToList();
        var flashCount = 0;

        var i = 0;
        while (true)
        {
            var flashed = new HashSet<Coord>();

            IncrementAll(coords, grid);
            var coordsToFlash = GetCoordsToFlash(coords, grid);

            while (coordsToFlash.Any())
            {
                var flashCoord = coordsToFlash.First();
                grid.MoveTo(flashCoord);
                grid.WriteValue(0);
                flashed.Add(flashCoord);

                foreach (var adjacentCoord in grid.AllAdjacentCoords)
                {
                    if (flashed.Contains(adjacentCoord))
                        continue;

                    grid.MoveTo(adjacentCoord);
                    var adjacentValue = grid.ReadValue();
                    var newAdjacentValue = adjacentValue + 1;
                    grid.WriteValue(newAdjacentValue);
                }

                coordsToFlash = GetCoordsToFlash(coords, grid);
            }

            flashCount += flashed.Count;

            if (i >= maxSteps - 1)
                return flashCount;

            i++;

            if (flashed.Count == coords.Count)
                return i;
        }
    }

    private static IList<Coord> GetCoordsToFlash(List<Coord> coords, Grid<int> grid) => coords.Where(o => grid.ReadValueAt(o) > 9).ToList();

    private static void IncrementAll(List<Coord> coords, Grid<int> grid)
    {
        foreach (var coord in coords)
            grid.WriteValueAt(coord, grid.ReadValueAt(coord) + 1);
    }
}