using Pzl.Common;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2017;

[Name("I Heard You Like Registers")]
public class Aoc201708 : AocPuzzle
{
    [Puzzle("3c0ff36b6914cd6851601f65f68e9637")]
    public int Part1(string input)
    {
        var (largestValueAtEnd, _) = Solve(input);
        return largestValueAtEnd;
    }

    [Puzzle("e2ede6d54359a751cf2c2bdae941840b")]
    public int Part2(string input)
    {
        var (_, largestValueEver) = Solve(input);
        return largestValueEver;
    }

    public (int, int) Solve(string input)
    {
        var largestValueAtEnd = 0;
        var largestValueEver = 0;
        var registers = new Dictionary<string, int>();
        var instructions = input.Split(LineBreaks.Single);
            
        foreach (var instruction in instructions)
        {
            var parts = instruction.Split(' ');
            var targetRegister = parts[0];
            var change = parts[1] == "inc" ? 1 : -1;
            var value = int.Parse(parts[2]);
            var readRegister = parts[4];
            var condition = parts[5];
            var compareValue = int.Parse(parts[6]);
            
            var currentValue = ReadValue(registers, targetRegister);
            var targetValue = currentValue + change * value;
                
            if(TestCondition(ReadValue(registers, readRegister), condition, compareValue))
                registers[targetRegister] = targetValue;

            var largestValue = registers.Values.Max();
            if (largestValue > largestValueEver)
                largestValueEver = largestValue;
        }

        largestValueAtEnd = registers.Values.Max();

        return (largestValueAtEnd, largestValueEver);
    }

    private static int ReadValue(Dictionary<string, int> registers, string key)
    {
        registers.TryAdd(key, 0);
        return registers[key];
    }

    private static bool TestCondition(int a, string condition, int b) => condition switch
    {
        ">" => a > b,
        "<" => a < b,
        ">=" => a >= b,
        "<=" => a <= b,
        "==" => a == b,
        "!=" => a != b,
        _ => false
    };
}