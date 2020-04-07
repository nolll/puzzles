using System.Collections.Generic;
using Core.Tools;

namespace Core.CoprocessorConflagration
{
    public class CoProcessor
    {
        private readonly IList<string> _operations;
        private readonly IDictionary<string, long> _registers;
        private long _currentOperation;

        private bool IsRunning => _currentOperation < _operations.Count && _currentOperation >= 0;
        public int MulCount { get; private set; }

        public CoProcessor(string input)
            : this(PuzzleInputReader.Read(input))
        {
        }

        public CoProcessor(IList<string> operations)
        {
            _operations = operations;
            _registers = new Dictionary<string, long>();
        }

        public void Run()
        {
            while (IsRunning)
            {
                var operation = _operations[(int)_currentOperation];
                var parts = operation.Split(' ');
                var command = parts[0];
                var part1 = parts[1];
                var val1IsNumeric = long.TryParse(part1, out var val1);
                val1 = !val1IsNumeric && _registers.ContainsKey(part1) ? _registers[part1] : val1;

                var part2 = parts.Length > 2 ? parts[2] : null;
                long val2 = 0;
                var val2IsNumeric = part2 != null && long.TryParse(part2, out val2);
                val2 = !val2IsNumeric && part2 != null && _registers.ContainsKey(part2) ? _registers[part2] : val2;

                if (command == "set")
                {
                    _registers[part1] = val2;
                }
                else if (command == "add")
                {
                    _registers.TryGetValue(part1, out var oldVal);
                    _registers[part1] = oldVal + val2;
                }
                else if (command == "sub")
                {
                    _registers.TryGetValue(part1, out var oldVal);
                    _registers[part1] = oldVal - val2;
                }
                else if (command == "mul")
                {
                    MulCount++;
                    _registers.TryGetValue(part1, out var oldVal);
                    _registers[part1] = oldVal * val2;
                }
                else if (command == "mod")
                {
                    _registers.TryGetValue(part1, out var oldVal);
                    _registers[part1] = oldVal % val2;
                }
                else if (command == "jgz")
                {
                    if (val1 > 0)
                    {
                        _currentOperation += val2;
                        continue;
                    }
                }
                else if (command == "jnz")
                {
                    if (val1 != 0)
                    {
                        _currentOperation += val2;
                        continue;
                    }
                }

                _currentOperation++;
            }
        }
    }
}