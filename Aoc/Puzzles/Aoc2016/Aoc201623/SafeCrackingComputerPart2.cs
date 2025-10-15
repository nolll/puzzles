using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2016.Aoc201623;

public class SafeCrackingComputerPart2
{
    private readonly Dictionary<char, int> _registers;
    private int _index;

    public int ValueA => _registers['a'];

    public SafeCrackingComputerPart2(string input, int a, int c)
    {
        var instructions = StringReader.ReadLines(input).Select(o => new AssembunnyInstruction(o)).ToArray();
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
            try
            {
                if (command == "cpy")
                {
                    var value = s.Args[0];
                    var target = s.Args[1].First();
                    _registers[target] = int.TryParse(value, out var num) 
                        ? num 
                        : _registers[value.First()];

                    IncrementIndex();
                }

                else if (command == "inc")
                {
                    var target = s.Args[0].First();
                    _registers[target]++;
                    IncrementIndex();
                }

                else if (command == "dec")
                {
                    var target = s.Args[0].First();
                    _registers[target]--;
                    IncrementIndex();
                }

                else if (command == "jnz")
                {
                    var value = s.Args[0];
                    var isInt = int.TryParse(s.Args[1], out var steps);
                    steps = isInt ? steps : _registers[s.Args[1].First()];

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
                    var indexToToggle = _index + _registers[s.Args[0].First()];
                    if (indexToToggle >= 0 && indexToToggle < instructions.Length)
                    {
                        var instructionToToggle = instructions[indexToToggle];
                        var name = instructionToToggle.Name;
                        if (instructionToToggle.Args.Count == 1)
                        {
                            instructionToToggle.Name = name == "inc" 
                                ? "dec" 
                                : "inc";
                        }
                        else
                        {
                            instructionToToggle.Name = name == "jnz" 
                                ? "cpy" 
                                : "jnz";
                        }
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