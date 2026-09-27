using Pzl.Common;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2016;

[IsSlow] // 98s for part 2
[Name("Safe Cracking")]
[Comment("Factorial of 12")]
public class Aoc201623 : AocPuzzle
{
    [Puzzle("11e66781d74c9188561ba3937d053d99")]
    public int Part1(string input) => new SafeCrackingComputerPart1(input, 7, 0).ValueA;

    [Puzzle("eb0c83e21e8bd77e7f0b5686e8f1c31a")]
    public int Part2(string input) => new SafeCrackingComputerPart2(input, 12, 0).ValueA;  // 12! + 7708
    
    public class AssembunnyInstruction
    {
        public string Name { get; set; }
        public IList<string> Args { get; }

        public AssembunnyInstruction(string s)
        {
            var parts = s.Split(' ');
            Name = parts.First();
            Args = parts.Skip(1).ToList();
        }
    }

    public class SafeCrackingComputerPart1
    {
        private readonly Dictionary<char, int> _registers;
        private int _index;

        public int ValueA => _registers['a'];

        public SafeCrackingComputerPart1(string input, int a, int c)
        {
            var instructions = input.Split(LineBreaks.Single);
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
                //Console.WriteLine($"{_index}. {s}");
                var parts = s.Split(' ');
                var command = parts[0];
                try
                {
                    if (command == "cpy")
                    {
                        var value = parts[1];
                        var target = parts[2].First();
                        if (int.TryParse(value, out var num))
                            _registers[target] = num;
                        else
                            _registers[target] = _registers[value.First()];

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

    public class SafeCrackingComputerPart2
    {
        private readonly Dictionary<char, int> _registers;
        private int _index;

        public int ValueA => _registers['a'];

        public SafeCrackingComputerPart2(string input, int a, int c)
        {
            var instructions = input.Split(LineBreaks.Single).Select(o => new AssembunnyInstruction(o)).ToArray();
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
                var command = s.Name;
                if (command == "cpy")
                {
                    var value = s.Args[0];
                    var target = s.Args[1][0];
                    _registers[target] = int.TryParse(value, out var num)
                        ? num
                        : _registers[value.First()];

                    IncrementIndex();
                }

                else if (command == "inc")
                {
                    var target = s.Args[0][0];
                    _registers[target]++;
                    IncrementIndex();
                }

                else if (command == "dec")
                {
                    var target = s.Args[0][0];
                    _registers[target]--;
                    IncrementIndex();
                }

                else if (command == "jnz")
                {
                    var value = s.Args[0];
                    var isInt = int.TryParse(s.Args[1], out var steps);
                    steps = isInt ? steps : _registers[s.Args[1][0]];

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
                    var indexToToggle = _index + _registers[s.Args[0][0]];
                    if (indexToToggle >= 0 && indexToToggle < instructions.Length)
                    {
                        var instructionToToggle = instructions[indexToToggle];
                        if (instructionToToggle.Args.Count == 1)
                        {
                            instructionToToggle.Name = instructionToToggle.Name == "inc"
                                ? "dec"
                                : "inc";
                        }
                        else
                        {
                            instructionToToggle.Name = instructionToToggle.Name == "jnz"
                                ? "cpy"
                                : "jnz";
                        }
                    }

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