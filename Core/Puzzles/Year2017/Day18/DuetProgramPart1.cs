using System.Collections.Generic;

namespace Core.Puzzles.Year2017.Day18
{
    public class DuetProgramPart1
    {
        private readonly IList<string> _operations;
        private readonly IDictionary<string, long> _registers;
        private long _playedSound;
        private long _currentOperation;

        private bool IsRunning => _currentOperation < _operations.Count && _currentOperation >= 0;

        public DuetProgramPart1(IList<string> operations)
        {
            _operations = operations;
            _registers = new Dictionary<string, long>();
        }

        public long FindFrequency()
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

                if (command == "snd")
                {
                    _playedSound = val1;
                }
                else if (command == "set")
                {
                    _registers[part1] = val2;
                }
                else if (command == "add")
                {
                    _registers.TryGetValue(part1, out var oldVal);
                    _registers[part1] = oldVal + val2;
                }
                else if (command == "mul")
                {
                    _registers.TryGetValue(part1, out var oldVal);
                    _registers[part1] = oldVal * val2;
                }
                else if (command == "mod")
                {
                    _registers.TryGetValue(part1, out var oldVal);
                    _registers[part1] = oldVal % val2;
                }
                else if (command == "rcv")
                {
                    if (val1 != 0)
                        return _playedSound;
                }
                else if (command == "jgz")
                {
                    if (val1 > 0)
                    {
                        _currentOperation += val2;
                        continue;
                    }
                }

                _currentOperation++;
            }

            return 0;
        }
    }
}