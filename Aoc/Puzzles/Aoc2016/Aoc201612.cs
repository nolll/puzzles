using Pzl.Common;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2016;

[Name("Leonardo's Monorail")]
public class Aoc201612 : AocPuzzle
{
    private const string CopyCommand = "cpy";
    private const string IncreaseCommand = "inc";
    private const string DecreaseCommand = "dec";
    private const string JumpCommand = "jnz";

    [Puzzle("4ba2fa440d50bec300e43771065afd61")]
    public int Part1(string input) => Run(input, 0, 0);

    [Puzzle("5c02e7d4176ed51a799484797ba99661")]
    public int Part2(string input) => Run(input, 0, 1);

    private static int Run(string input, int a, int c)
    {
        var instructions = input.Split(LineBreaks.Single);
        var registers = new Dictionary<char, int>
        {
            ['a'] = a,
            ['b'] = 0,
            ['c'] = c,
            ['d'] = 0
        };

        var index = 0;

        while (index < instructions.Length)
        {
            var s = instructions[index];
            var parts = s.Split(' ');
            var command = parts[0];
            try
            {
                if (command == CopyCommand)
                {
                    var value = parts[1];
                    var target = parts[2].First();
                    if (int.TryParse(value, out var num))
                    {
                        registers[target] = num;
                    }
                    else
                    {
                        registers[target] = registers[value.First()];
                    }

                    index += 1;
                }

                else if (command == IncreaseCommand)
                {
                    var target = parts[1].First();
                    registers[target]++;
                    index += 1;
                }

                else if (command == DecreaseCommand)
                {
                    var target = parts[1].First();
                    registers[target]--;
                    index += 1;
                }

                else if (command == JumpCommand)
                {
                    var value = parts[1];
                    var isInt = int.TryParse(parts[2], out var steps);
                    steps = isInt ? steps : registers[parts[2].First()];

                    if (int.TryParse(value, out var num))
                    {
                        index += num != 0 ? steps : 1;
                    }
                    else
                    {
                        index += registers[value.First()] != 0 ? steps : 1;
                    }
                }
            }
            catch
            {
                index += 1;
            }
        }

        return registers['a'];
    }
}