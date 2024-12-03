using System.Text.RegularExpressions;
using Pzl.Common;
using Pzl.Tools.Numbers;

namespace Pzl.Aoc.Puzzles.Aoc2024.Aoc202403;

[Name("Mull It Over")]
public class Aoc202403 : AocPuzzle
{
    public PuzzleResult Part1(string input)
    {
        var instructions = new Regex(@"mul\(\d+,\d+\)").Matches(input).Select(o => o.ToString());
        var pairs = instructions.Select(Numbers.IntsFromString).ToArray();
        var result = pairs.Sum(o => o[0] * o[1]);
        return new PuzzleResult(result, "106efdc638384c80769741faa573a260");
    }

    public PuzzleResult Part2(string input)
    {
        var instructions = new Regex(@"(mul\(\d+,\d+\)|do\(\)|don't\(\))").Matches(input).Select(o => o.ToString());

        var isEnabled = true;
        var total = 0L;
        foreach (var ins in instructions)
        {
            if (ins.StartsWith("do"))
            {
                isEnabled = ins == "do()"; 
                continue;
            }

            if (!isEnabled)
                continue;

            var pair = Numbers.IntsFromString(ins);
            total += pair[0] * pair[1];
        }
        
        return new PuzzleResult(total, "7c76f7c7072aeaf4950328540fc4266b");
    }
}