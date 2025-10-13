using Pzl.Tools.Grids.Grids2d;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2020.Aoc202024;

public class HexagonalFloor
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

    private readonly IEnumerable<List<string>> _instructions;
    private readonly Grid<char> _grid;
    private readonly Dictionary<string, List<Coord>> _adjacentCoordsCache;
    public int BlackTileCount => _grid.Values.Count(o => o == Black);

    public HexagonalFloor(string input)
    {
        var rows = StringReader.ReadLines(input);
        _instructions = rows.Select(ParseInstruction);
        _grid = new Grid<char>(defaultValue: Nothing);
        _adjacentCoordsCache = new Dictionary<string, List<Coord>>();
    }

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

    public void Arrange()
    {
        _grid.WriteValue(White);
        foreach (var instruction in _instructions)
        {
            _grid.MoveTo(_grid.StartCoord);
            foreach (var step in instruction)
            {
                switch (step)
                {
                    case NorthEast:
                        _grid.MoveUp();
                        _grid.MoveRight();
                        break;
                    case East:
                        _grid.MoveRight();
                        _grid.MoveRight();
                        break;
                    case SouthEast:
                        _grid.MoveDown();
                        _grid.MoveRight();
                        break;
                    case SouthWest:
                        _grid.MoveDown();
                        _grid.MoveLeft();
                        break;
                    case West:
                        _grid.MoveLeft();
                        _grid.MoveLeft();
                        break;
                    case NorthWest:
                        _grid.MoveUp();
                        _grid.MoveLeft();
                        break;
                }

                if (_grid.ReadValue() == Nothing)
                    _grid.WriteValue(White);
            }

            var tile = _grid.ReadValue() == Black ? White : Black;
            _grid.WriteValue(tile);
        }
    }

    public void Modify(int dayCount)
    {
        for (var day = 0; day < dayCount; day++)
        {
            _grid.ExtendUp(1);
            _grid.ExtendRight(2);
            _grid.ExtendDown(1);
            _grid.ExtendLeft(2);
            FillEmptyTilesWithWhite();
            ApplyRules();
        }
    }

    private void ApplyRules()
    {
        var tilesToFlipToBlack = new List<Coord>();
        var tilesToFlipToWhite = new List<Coord>();

        foreach (var coord in _grid.Coords)
        {
            var thisValue = _grid.ReadValueAt(coord);

            if (thisValue != Nothing)
            {
                var adjacentValues = GetAdjacent6Values(coord);
                var blackAdjacentCount = adjacentValues.Count(o => o == Black);
                if (thisValue == Black)
                {
                    // Any black tile with zero or more than 2 black tiles immediately adjacent to it is flipped to white.
                    if (blackAdjacentCount is 0 or > 2)
                    {
                        tilesToFlipToWhite.Add(coord);
                    }
                }
                else
                {
                    // Any white tile with exactly 2 black tiles immediately adjacent to it is flipped to black.
                    if (blackAdjacentCount == 2)
                    {
                        tilesToFlipToBlack.Add(coord);
                    }
                }
            }
        }

        foreach (var address in tilesToFlipToBlack)
        {
            _grid.WriteValueAt(address, Black);
        }

        foreach (var address in tilesToFlipToWhite)
        {
            _grid.WriteValueAt(address, White);
        }
    }

    private void FillEmptyTilesWithWhite()
    {
        var tilesToFill = new List<Coord>();

        foreach (var coord in _grid.Coords)
        {
            if (_grid.ReadValueAt(coord) != Nothing)
            {
                var adjacentAddresses = GetAdjacent6Coords(coord);
                var adjacentValues = GetAdjacent6Values(coord);
                if (adjacentValues.Any(o => o != Nothing))
                {
                    foreach (var address in adjacentAddresses)
                    {
                        if (_grid.TryMoveTo(address) && _grid.ReadValueAt(address) == Nothing)
                        {
                            tilesToFill.Add(_grid.Coord);
                        }
                    }
                }
            }
        }
        
        foreach (var address in tilesToFill)
        {
            _grid.WriteValueAt(address, White);
        }
    }

    private List<char> GetAdjacent6Values(Coord coord)
    {
        var currentAddress = _grid.Coord;
        var addresses = GetAdjacent6Coords(coord);
        var values = new List<char>();
        foreach (var address in addresses)
        {
            if (_grid.TryMoveTo(address))
            {
                values.Add(_grid.ReadValue());
            }
        }

        _grid.MoveTo(currentAddress);
        return values;
    }

    private List<Coord> GetAdjacent6Coords(Coord coord)
    {
        var key = coord.Id;
        if (_adjacentCoordsCache.TryGetValue(key, out var coords))
            return coords;
            
        coords = new List<Coord>
        {
            new(coord.X + 1, coord.Y - 1),
            new(coord.X + 2, coord.Y),
            new(coord.X + 1, coord.Y + 1),
            new(coord.X - 1, coord.Y + 1),
            new(coord.X - 2, coord.Y),
            new(coord.X - 1, coord.Y - 1)
        };
            
        _adjacentCoordsCache.Add(key, coords);
        return coords;
    }
}