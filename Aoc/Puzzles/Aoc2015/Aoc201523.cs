using Pzl.Common;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2015;

[Name("Opening the Turing Lock")]
public class Aoc201523 : AocPuzzle
{
    [Puzzle("33adfc1e185fd4bc7ea824d0c6a24aa0")]
    public int Part1(string input) => Run([], input)['b'];

    [Puzzle("147654bb6c5385ca3e588af0f2a1b077")]
    public int Part2(string input) => Run([], input, 1)['b'];

    public Dictionary<char, int> Run(Dictionary<char, int> registers, string program, int a = 0)
    {
        registers['a'] = a;
        registers['b'] = 0;

        var instructions = program.Split(LineBreaks.Single);
        var pointer = 0;
        while (pointer >= 0 && pointer < instructions.Length)
        {
            var instruction = instructions[pointer];
            var parts = instruction.Split(' ');
            var name = parts[0];

            if (name == "hlf")
            {
                var register = parts[1].First();
                registers[register] /= 2;
                pointer++;
            }
            else if (name == "tpl")
            {
                var register = parts[1].First();
                registers[register] *= 3;
                pointer++;
            }
            else if (name == "inc")
            {
                var register = parts[1].First();
                registers[register] += 1;
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
                if (registers[register] % 2 == 0)
                    pointer += offset;
                else
                    pointer++;
            }
            else if (name == "jio")
            {
                var register = parts[1].Replace(",", "").First();
                var offset = int.Parse(parts[2].Replace("+", ""));
                if (registers[register] == 1)
                    pointer += offset;
                else
                    pointer++;
            }
        }

        return registers;
    }
}