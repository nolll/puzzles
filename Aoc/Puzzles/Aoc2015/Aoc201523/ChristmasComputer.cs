using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2015.Aoc201523;

public class ChristmasComputer
{
    private readonly Dictionary<char, int> _registers = [];

    public int RegisterA => _registers['a'];
    public int RegisterB => _registers['b'];

    public void Run(string program, int a = 0)
    {
        _registers['a'] = a;
        _registers['b'] = 0;

        var instructions = StringReader.ReadLines(program);
        var pointer = 0;
        while (pointer >= 0 && pointer < instructions.Count)
        {
            var instruction = instructions[pointer];
            var parts = instruction.Split(' ');
            var name = parts[0];

            if (name == "hlf")
            {
                var register = parts[1].First();
                _registers[register] /= 2;
                pointer++;
            }
            else if (name == "tpl")
            {
                var register = parts[1].First();
                _registers[register] *= 3;
                pointer++;
            }
            else if (name == "inc")
            {
                var register = parts[1].First();
                _registers[register] += 1;
                pointer++;
            }
            else if (name == "jmp")
            {
                var offset = int.Parse(parts[1].Replace("+", ""));
                pointer += offset;
            }
            else if (name == "jie")
            {
                var register = parts[1].Replace(",", "").First();
                var offset = int.Parse(parts[2].Replace("+", ""));
                if (_registers[register] % 2 == 0)
                    pointer += offset;
                else
                    pointer++;
            }
            else if (name == "jio")
            {
                var register = parts[1].Replace(",", "").First();
                var offset = int.Parse(parts[2].Replace("+", ""));
                if (_registers[register] == 1)
                    pointer += offset;
                else
                    pointer++;
            }
        }
    }
}