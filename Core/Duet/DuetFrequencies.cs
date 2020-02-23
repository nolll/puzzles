using System.Collections.Generic;
using Core.Tools;

namespace Core.Duet
{
    public class DuetFrequencies
    {
        private readonly IList<string> _operations;
        private readonly IDictionary<string, long> _registers;
        private long _playedSound;
        
        public DuetFrequencies(string input)
        {
            _operations = PuzzleInputReader.Read(input);
            _registers = new Dictionary<string, long>();
        }

        public long FindFrequency()
        {
            long i = 0;
            while (i < _operations.Count && i >= 0)
            {
                var operation = _operations[(int)i];
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
                if (command == "set")
                {
                    _registers[part1] = val2;
                }
                if (command == "add")
                {
                    _registers.TryGetValue(part1, out var oldVal);
                    _registers[part1] = oldVal + val2;
                }
                if (command == "mul")
                {
                    _registers.TryGetValue(part1, out var oldVal);
                    _registers[part1] = oldVal * val2;
                }
                if (command == "mod")
                {
                    _registers.TryGetValue(part1, out var oldVal);
                    _registers[part1] = oldVal % val2;
                }
                if (command == "rcv")
                {
                    if (val1 != 0)
                        return _playedSound;
                }
                if (command == "jgz")
                {
                    if (val1 > 0)
                    {
                        i += val2;
                        continue;
                    }
                }

                i++;
            }

            return 0;
        }
    }
}