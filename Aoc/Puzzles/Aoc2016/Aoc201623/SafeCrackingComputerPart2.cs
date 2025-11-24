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