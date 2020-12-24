using System.Collections.Generic;
using System.Linq;
using Core.Tools;

namespace Core.HexagonalFlooring
{
    public class HexagonalFloor
    {
        private const char Nothing = ' ';
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
        public int BlackTileCount => _matrix.Values.Count(o => o == Black);

        public HexagonalFloor(string input)
        {
            var rows = PuzzleInputReader.ReadLines(input);
            _instructions = rows.Select(ParseInstruction);
            _matrix = new Matrix<char>(defaultValue: ' ');
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
    }
}