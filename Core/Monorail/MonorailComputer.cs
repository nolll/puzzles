using System.Collections.Generic;
using System.Linq;
using Core.Tools;

namespace Core.Monorail
{
    public class MonorailComputer
    {
        private readonly Dictionary<char, int> _registers;
        private int _index;

        public int ValueA => _registers['a'];

        public MonorailComputer(string input, int a, int c)
        {
            var instructions = PuzzleInputReader.ReadLines(input).ToArray();
            _registers = new Dictionary<char, int>
            {
                ['a'] = a,
                ['b'] = 0,
                ['c'] = c,
                ['d'] = 0
            };
            _index = 0;

            while (_index < instructions.Length)
            {
                var s = instructions[_index];
                var parts = s.Split(' ');
                var command = parts[0];
                try
                {
                    if (command == "cpy")
                    {
                        var value = parts[1];
                        var target = parts[2].First();
                        if (int.TryParse(value, out var num))
                        {
                            _registers[target] = num;
                        }
                        else
                        {
                            _registers[target] = _registers[value.First()];
                        }

                        IncrementIndex();
                    }

                    else if (command == "inc")
                    {
                        var target = parts[1].First();
                        _registers[target]++;
                        IncrementIndex();
                    }

                    else if (command == "dec")
                    {
                        var target = parts[1].First();
                        _registers[target]--;
                        IncrementIndex();
                    }

                    else if (command == "jnz")
                    {
                        var value = parts[1];
                        var isInt = int.TryParse(parts[2], out var steps);
                        steps = isInt ? steps : _registers[parts[2].First()];

                        if (int.TryParse(value, out var num))
                        {
                            IncrementIndex(num != 0 ? steps : 1);
                        }
                        else
                        {
                            IncrementIndex(_registers[value.First()] != 0 ? steps : 1);
                        }
                    }

                    else if (command == "tgl")
                    {
                        var target = parts[1].First();
                        var val = _registers[target];
                        var indexToToggle = _index + val;
                        if (indexToToggle >= 0 && indexToToggle < instructions.Length)
                        {
                            var instructionToToggle = instructions[indexToToggle];
                            var toggleParts = instructionToToggle.Split(" ");
                            var name = toggleParts[0];
                            if (toggleParts.Length == 2)
                            {
                                if (name == "inc")
                                    toggleParts[0] = "dec";
                                else
                                    toggleParts[0] = "inc";
                            }
                            else
                            {
                                if (name == "jnz")
                                    toggleParts[0] = "cpy";
                                else
                                    toggleParts[0] = "jnz";
                            }

                            instructions[indexToToggle] = string.Join(' ', toggleParts);
                        }

                        IncrementIndex();
                    }
                }
                catch
                {
                    IncrementIndex();
                }
            }
        }

        private void IncrementIndex(int steps = 1)
        {
            _index += steps;
        }
    }
}
