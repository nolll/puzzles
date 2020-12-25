using System.Collections.Generic;
using System.Linq;
using Core.Tools;

namespace Core.HexagonalFlooring
{
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
        private Matrix<char> _matrix;
        public int BlackTileCount => _matrix.Values.Count(o => o == Black);

        public HexagonalFloor(string input)
        {
            var rows = PuzzleInputReader.ReadLines(input);
            _instructions = rows.Select(ParseInstruction);
            _matrix = new Matrix<char>(defaultValue: Nothing);
        }

        private List<string> ParseInstruction(string s)
        {
            var instructions = new List<string>();
            var array = s.ToCharArray();
            for (var i = 0; i < array.Length; i++)
            {
                var c = array[i];
                if (c == 'w' || c == 'e')
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
                    if (step == NorthEast)
                    {
                        _matrix.MoveUp();
                        _matrix.MoveRight();
                    }
                    else if (step == East)
                    {
                        _matrix.MoveRight();
                        _matrix.MoveRight();
                    }
                    if (step == SouthEast)
                    {
                        _matrix.MoveDown();
                        _matrix.MoveRight();
                    }
                    if (step == SouthWest)
                    {
                        _matrix.MoveDown();
                        _matrix.MoveLeft();
                    }
                    else if (step == West)
                    {
                        _matrix.MoveLeft();
                        _matrix.MoveLeft();
                    }
                    if (step == NorthWest)
                    {
                        _matrix.MoveUp();
                        _matrix.MoveLeft();
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
            for (var y = 0; y < _matrix.Height; y++)
            {
                for (var x = 0; x < _matrix.Width; x++)
                {
                    _matrix.MoveTo(x, y);
                    var thisValue = _matrix.ReadValue();

                    if (thisValue != Nothing)
                    {
                        var adjacentValues = GetAdjacent6Values(x, y);
                        var blackAdjacentCount = adjacentValues.Count(o => o == Black);
                        if (thisValue == Black)
                        {
                            // Any black tile with zero or more than 2 black tiles immediately adjacent to it is flipped to white.
                            if (blackAdjacentCount == 0 || blackAdjacentCount > 2)
                            {
                                tilesToFlipToWhite.Add(_matrix.Address);
                            }
                        }
                        else
                        {
                            // Any white tile with exactly 2 black tiles immediately adjacent to it is flipped to black.
                            if (blackAdjacentCount == 2)
                            {
                                tilesToFlipToBlack.Add(_matrix.Address);
                            }
                        }
                    }
                }
            }

            foreach (var address in tilesToFlipToBlack)
            {
                _matrix.MoveTo(address);
                _matrix.WriteValue(Black);
            }

            foreach (var address in tilesToFlipToWhite)
            {
                _matrix.MoveTo(address);
                _matrix.WriteValue(White);
            }
        }

        private void FillEmptyTilesWithWhite()
        {
            var tilesToFill = new List<MatrixAddress>();
            for (var y = 0; y < _matrix.Height; y++)
            {
                for (var x = 0; x < _matrix.Width; x++)
                {
                    _matrix.MoveTo(x, y);
                    var thisValue = _matrix.ReadValue();
                    if (thisValue != Nothing)
                    {
                        var adjacentAddresses = GetAdjacent6Coords(x, y);
                        var adjacentValues = GetAdjacent6Values(x, y);
                        if (adjacentAddresses.Count == 6 && adjacentValues.Any(o => o != Nothing))
                        {
                            foreach (var address in adjacentAddresses)
                            {
                                if (_matrix.TryMoveTo(address))
                                {
                                    if (_matrix.ReadValue() == Nothing)
                                        tilesToFill.Add(_matrix.Address);
                                }
                            }
                        }
                    }
                }
            }

            foreach (var address in tilesToFill)
            {
                _matrix.MoveTo(address);
                _matrix.WriteValue(White);
            }
        }

        private List<char> GetAdjacent6Values(int x, int y)
        {
            var currentAddress = _matrix.Address;
            var addresses = GetAdjacent6Coords(x, y);
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

        private List<MatrixAddress> GetAdjacent6Coords(int x, int y)
        {
            var northEast = new MatrixAddress(x + 1, y - 1);
            var east = new MatrixAddress(x + 2, y);
            var southEast = new MatrixAddress(x + 1, y + 1);
            var southWest = new MatrixAddress(x - 1, y + 1);
            var west = new MatrixAddress(x - 2, y);
            var northWest = new MatrixAddress(x - 1, y - 1);

            return new List<MatrixAddress>
            {
                northEast,
                east,
                southEast,
                southWest,
                west,
                northWest
            };
        }
    }
}