using Puzzles.common.CoordinateSystems.CoordinateSystem2D;
using Puzzles.common.Strings;

namespace Puzzles.aoc.Puzzles.Aoc2020.Aoc202024;

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
    private readonly Matrix<char> _matrix;
    private readonly Dictionary<string, List<MatrixAddress>> _adjacentCoordsCache;
    public int BlackTileCount => _matrix.Values.Count(o => o == Black);

    public HexagonalFloor(string input)
    {
        var rows = StringReader.ReadLines(input);
        _instructions = rows.Select(ParseInstruction);
        _matrix = new Matrix<char>(defaultValue: Nothing);
        _adjacentCoordsCache = new Dictionary<string, List<MatrixAddress>>();
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
        _matrix.WriteValue(White);
        foreach (var instruction in _instructions)
        {
            _matrix.MoveTo(_matrix.StartAddress);
            foreach (var step in instruction)
            {
                switch (step)
                {
                    case NorthEast:
                        _matrix.MoveUp();
                        _matrix.MoveRight();
                        break;
                    case East:
                        _matrix.MoveRight();
                        _matrix.MoveRight();
                        break;
                    case SouthEast:
                        _matrix.MoveDown();
                        _matrix.MoveRight();
                        break;
                    case SouthWest:
                        _matrix.MoveDown();
                        _matrix.MoveLeft();
                        break;
                    case West:
                        _matrix.MoveLeft();
                        _matrix.MoveLeft();
                        break;
                    case NorthWest:
                        _matrix.MoveUp();
                        _matrix.MoveLeft();
                        break;
                }

                if (_matrix.ReadValue() == Nothing)
                    _matrix.WriteValue(White);
            }

            var tile = _matrix.ReadValue() == Black ? White : Black;
            _matrix.WriteValue(tile);
        }
    }

    public void Modify(int dayCount)
    {
        for (var day = 0; day < dayCount; day++)
        {
            _matrix.ExtendUp(1);
            _matrix.ExtendRight(2);
            _matrix.ExtendDown(1);
            _matrix.ExtendLeft(2);
            FillEmptyTilesWithWhite();
            ApplyRules();
        }
    }

    private void ApplyRules()
    {
        var tilesToFlipToBlack = new List<MatrixAddress>();
        var tilesToFlipToWhite = new List<MatrixAddress>();

        foreach (var coord in _matrix.Coords)
        {
            var thisValue = _matrix.ReadValueAt(coord);

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
            _matrix.WriteValueAt(address, Black);
        }

        foreach (var address in tilesToFlipToWhite)
        {
            _matrix.WriteValueAt(address, White);
        }
    }

    private void FillEmptyTilesWithWhite()
    {
        var tilesToFill = new List<MatrixAddress>();

        foreach (var coord in _matrix.Coords)
        {
            if (_matrix.ReadValueAt(coord) != Nothing)
            {
                var adjacentAddresses = GetAdjacent6Coords(coord);
                var adjacentValues = GetAdjacent6Values(coord);
                if (adjacentValues.Any(o => o != Nothing))
                {
                    foreach (var address in adjacentAddresses)
                    {
                        if (_matrix.TryMoveTo(address) && _matrix.ReadValueAt(address) == Nothing)
                        {
                            tilesToFill.Add(_matrix.Address);
                        }
                    }
                }
            }
        }
        
        foreach (var address in tilesToFill)
        {
            _matrix.WriteValueAt(address, White);
        }
    }

    private List<char> GetAdjacent6Values(MatrixAddress coord)
    {
        var currentAddress = _matrix.Address;
        var addresses = GetAdjacent6Coords(coord);
        var values = new List<char>();
        foreach (var address in addresses)
        {
            if (_matrix.TryMoveTo(address))
            {
                values.Add(_matrix.ReadValue());
            }
        }

        _matrix.MoveTo(currentAddress);
        return values;
    }

    private List<MatrixAddress> GetAdjacent6Coords(MatrixAddress coord)
    {
        var key = coord.Id;
        if (_adjacentCoordsCache.TryGetValue(key, out var coords))
            return coords;
            
        coords = new List<MatrixAddress>
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