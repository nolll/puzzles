using System.Text.RegularExpressions;
using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2024.Aoc202403;

[Name("Mull It Over")]
public class Aoc202403 : AocPuzzle
{
    public PuzzleResult Part1(string input)
    {
        var muls = new Regex("mul\\(\\d+,\\d+\\)").Matches(input).Select(o => o.ToString());
        var operations = muls.Select(ParseOperation).ToArray();
        var result = operations.Sum(o => o.Item1 * o.Item2);
        return new PuzzleResult(result, "106efdc638384c80769741faa573a260");
    }

    private (long, long) ParseOperation(string o)
    {
        var s = o.Replace("mul(", "").Replace(")", "");
        var parts = s.Split(',').Select(long.Parse).ToArray();
        return (parts[0], parts[1]);
    }

    public PuzzleResult Part2(string input)
    {
        var instructions = new Regex("(mul\\(\\d+,\\d+\\)|do\\(\\)|don't\\(\\))").Matches(input).Select(o => o.ToString());

        var isEnabled = true;
        var total = 0L;
        foreach (var ins in instructions)
        {
            if(ins == "do()")
            {
                isEnabled = true;
                continue;
            }
            
            if(ins == "don't()")
            {
                isEnabled = false;
                continue;
            }

            if (!isEnabled)
                continue;
            
            var s = ins.Replace("mul(", "").Replace(")", "");
            var parts = s.Split(',').Select(long.Parse).ToArray();
            total += parts[0] * parts[1];
        }
        
        return new PuzzleResult(total, "7c76f7c7072aeaf4950328540fc4266b");
    }
}