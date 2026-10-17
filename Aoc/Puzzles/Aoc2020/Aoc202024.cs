using Pzl.Common;
using Pzl.Tools.Grids.Grids2d;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2020;

[Name("Lobby Layout")]
public class Aoc202024 : AocPuzzle
{

    private const char Nothing = '.';
    private const char White = 'w';
    private const char Black = 'b';

    private const string NorthEast = "ne";
    private const string East = "e";
    private const string SouthEast = "se";
    private const string SouthWest = "sw";
    private const string West = "w";
    private const string NorthWest = "nw";

    [Puzzle("5d93c546616fcdf4656b6333d8457200")]
    public int Part1(string input) => BlackTileCount(Arrange(input));

    [Puzzle("812d3dec4e5955c3c44ead98ed889522")]
    public int Part2(string input, int modifications = 100) => BlackTileCount(Modify(Arrange(input), modifications, []));

    public int BlackTileCount(Grid<char> grid) => grid.Values.Count(o => o == Black);

    private static List<string> ParseInstruction(string s)
    {
        var instructions = new List<string>();
        var array = s.ToCharArray();
        for (var i = 0; i < array.Length; i++)
        {
            var c = array[i];
            if (c is 'w' or 'e')
            {
                instructions.Add(c.ToString());
            }
            else
            {
                var nextChar = array[i + 1];
                instructions.Add($"{c}{nextChar}");
                i++;
            }
        }

        return instructions;
    }

    public Grid<char> Arrange(string input)
    {
        var instructions = input.Split(LineBreaks.Single).Select(ParseInstruction);
        var grid = new Grid<char>(defaultValue: Nothing);
        grid.WriteValue(White);
        foreach (var instruction in instructions)
        {
            grid.MoveTo(grid.StartCoord);
            foreach (var step in instruction)
            {
                switch (step)
                {
                    case NorthEast:
                        grid.MoveUp();
                        grid.MoveRight();
                        break;
                    case East:
                        grid.MoveRight();
                        grid.MoveRight();
                        break;
                    case SouthEast:
                        grid.MoveDown();
                        grid.MoveRight();
                        break;
                    case SouthWest:
                        grid.MoveDown();
                        grid.MoveLeft();
                        break;
                    case West:
                        grid.MoveLeft();
                        grid.MoveLeft();
                        break;
                    case NorthWest:
                        grid.MoveUp();
                        grid.MoveLeft();
                        break;
                }

                if (grid.ReadValue() == Nothing)
                    grid.WriteValue(White);
            }

            var tile = grid.ReadValue() == Black ? White : Black;
            grid.WriteValue(tile);
        }

        return grid;
    }

    public Grid<char> Modify(Grid<char> grid, int dayCount, Dictionary<string, List<Coord>> cache)
    {
        for (var day = 0; day < dayCount; day++)
        {
            grid.ExtendUp();
            grid.ExtendRight(2);
            grid.ExtendDown();
            grid.ExtendLeft(2);
            FillEmptyTilesWithWhite(grid, cache);
            ApplyRules(grid, cache);
        }

        return grid;
    }

    private void ApplyRules(Grid<char> grid, Dictionary<string, List<Coord>> cache)
    {
        var tilesToFlipToBlack = new List<Coord>();
        var tilesToFlipToWhite = new List<Coord>();

        foreach (var coord in grid.Coords)
        {
            var thisValue = grid.ReadValueAt(coord);

            if (thisValue == Nothing)
                continue;

            var adjacentValues = GetAdjacent6Values(grid, coord, cache);
            var blackAdjacentCount = adjacentValues.Count(o => o == Black);
            if (thisValue == Black && blackAdjacentCount is 0 or > 2)
                tilesToFlipToWhite.Add(coord);
            else if (blackAdjacentCount == 2)
                tilesToFlipToBlack.Add(coord);
        }

        foreach (var coord in tilesToFlipToBlack)
            grid.WriteValueAt(coord, Black);

        foreach (var coord in tilesToFlipToWhite)
            grid.WriteValueAt(coord, White);
    }

    private static void FillEmptyTilesWithWhite(Grid<char> grid, Dictionary<string, List<Coord>> cache)
    {
        var tilesToFill = new List<Coord>();

        foreach (var coord in grid.Coords)
        {
            if (grid.ReadValueAt(coord) == Nothing)
                continue;

            var adjacentValues = GetAdjacent6Values(grid, coord, cache);
            if (adjacentValues.All(o => o == Nothing))
                continue;

            var adjacentCoords = GetAdjacent6Coords(coord, cache);
            foreach (var adj in adjacentCoords)
            {
                if (grid.TryMoveTo(adj) && grid.ReadValueAt(adj) == Nothing)
                {
                    tilesToFill.Add(grid.Coord);
                }
            }
        }

        foreach (var address in tilesToFill)
            grid.WriteValueAt(address, White);
    }

    private static List<char> GetAdjacent6Values(Grid<char> grid, Coord coord, Dictionary<string, List<Coord>> cache) =>
        [.. GetAdjacent6Coords(coord, cache).Where(o => !grid.IsOutOfRange(o)).Select(grid.ReadValueAt)];

    private static List<Coord> GetAdjacent6Coords(Coord coord, Dictionary<string, List<Coord>> cache)
    {
        var key = coord.Id;
        if (cache.TryGetValue(key, out var coords))
            return coords;

        coords =
        [
            coord.Relative(1, -1),
            coord.Relative(2, 0),
            coord.Relative(1, 1),
            coord.Relative(-1, 1),
            coord.Relative(-2, 0),
            coord.Relative(-1, -1)
        ];

        cache.Add(key, coords);
        return coords;
    }
}